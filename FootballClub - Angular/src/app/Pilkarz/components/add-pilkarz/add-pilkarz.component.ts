import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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
  kluby: Klub[] = [];
  obecnyKlubReal!: Klub;
  idKlub!: string;
  pozycje: string[] = ['BR', 'ŚO', 'PO', 'LO', 'CPS', 'CLS', 'ŚPD', 'ŚP', 'ŚPO', 'LP', 'PP', 'LS', 'PS', 'ŚN', 'N']

  pilkarz = new FormGroup({
    imie: new FormControl('', Validators.required),
    nazwisko: new FormControl('', Validators.required),
    wiek: new FormControl('', Validators.required),
    pozycja: new FormControl('', Validators.required),
    wynagrodzenie: new FormControl('', Validators.required),
    statystyki: new FormControl('', Validators.required),
    kluby: new FormControl('', Validators.required),
    idKlub: new FormControl('', Validators.required)
  });

  constructor(private pilkarzService: PilkarzService, private klubyService: KlubService, private statystykiService: StatystykaService,
    private router: Router) {
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
    let klub = this.kluby.find(k => k.nazwa.includes("Real Madryt"));
  }

  getKluby(): void {
    this.klubyService.DajKluby().subscribe(res => {
      this.kluby = res;
    })
  }

  getBack(): void {
    this.router.navigateByUrl("/Pilkarze");
  }


  DodajPilkarza(): void {

    this.pilkarz.value.statystyki = null;
    this.pilkarz.value.kluby = null;
    console.log(this.pilkarz.value);
    if (this.pilkarz.value.idKlub) {
      this.pilkarzService.DodajPilkarza(this.pilkarz.value, this.pilkarz.value?.idKlub).subscribe(res => {
        console.log("Utworzono nowego piłkarza");
        this.router.navigateByUrl("/Pilkarze");
      })
    }
  }

}
