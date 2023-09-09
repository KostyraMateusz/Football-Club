import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Klub } from 'src/app/Klub/Models/klub.model';
import { KlubService } from 'src/app/Services/klub.service';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { StatystykaService } from 'src/app/Services/statystyka.service';
import { Statystyka } from 'src/app/Statystyka/Models/statystyka.model';

@Component({
  selector: 'app-add-pilkarz',
  templateUrl: './add-pilkarz.component.html',
  styleUrls: ['./add-pilkarz.component.css']
})
export class AddPilkarzComponent implements OnInit {

  statystyki: Statystyka[] = [];
  archiwalneKluby: Klub[] = [];
  obecnyKlubReal!: Klub;
  idKlub!: string;

  pilkarz = new FormGroup({
    imie: new FormControl('', Validators.required),
    nazwisko: new FormControl('', Validators.required),
    wiek: new FormControl('', Validators.required),
    pozycja: new FormControl('', Validators.required),
    wynagrodzenie: new FormControl('', Validators.required),
    statystyki: new FormControl('', Validators.required),
    archiwalneKluby: new FormControl('', Validators.required),
    idKlub: new FormControl('', Validators.required)
  });

  constructor(private pilkarzService: PilkarzService, private klubyService: KlubService, private statystykiService: StatystykaService) {
    this.getStatystyki();
    this.getKluby();
    this.getObecnyKlubReal();
  }

  ngOnInit(): void {
    this.getStatystyki();
    this.getKluby();
  }

  getStatystyki(): void {
    this.statystykiService.DajStatystyki().subscribe(res => {
      this.statystyki = res;
    })
  }

  getObecnyKlubReal(): void {
    console.log(this.archiwalneKluby);
    let klub = this.archiwalneKluby.find(k => k.nazwa.includes("Real Madryt"));
    console.log(klub);
    console.log(klub?.idKlub);
  }

  getKluby(): void {
    this.klubyService.DajKluby().subscribe(res => {
      this.archiwalneKluby = res;
    })
  }

  DodajPilkarza(): void {
    console.log(this.pilkarz.value);
    this.pilkarz.value.idKlub = '';
    this.pilkarzService.DodajPilkarza(this.pilkarz.value).subscribe(res => {
      console.log("Utworzono nowego piłkarza")
    })
  }

}
