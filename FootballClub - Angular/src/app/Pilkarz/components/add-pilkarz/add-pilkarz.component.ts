import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { KlubRequest } from 'src/app/Klub/Models/klub-request';
import { KlubService } from 'src/app/Services/klub.service';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { StatystykaService } from 'src/app/Services/statystyka.service';
import { StatystykaRequest } from 'src/app/Statystyka/Models/statystyka-request';

@Component({
  selector: 'app-add-pilkarz',
  templateUrl: './add-pilkarz.component.html',
  styleUrls: ['./add-pilkarz.component.css']
})
export class AddPilkarzComponent implements OnInit {

  statystyki: StatystykaRequest[] = [];
  archiwalneKluby: KlubRequest[] = [];

  pilkarz = new FormGroup({
    Imie: new FormControl('', Validators.required),
    Nazwisko: new FormControl('', Validators.required),
    Wiek: new FormControl('', Validators.required),
    Pozycja: new FormControl('', Validators.required),
    Wynagrodzenie: new FormControl('', Validators.required),
    Statystyki: new FormControl('', Validators.required),
    ArchiwalneKluby: new FormControl('', Validators.required),
  });

  constructor(private pilkarzService: PilkarzService, private klubyService: KlubService, private statystykiService: StatystykaService) {
    this.getStatystyki();
    this.getKluby();
  }

  ngOnInit(): void {
    this.getStatystyki();
    this.getKluby();
  }

  getStatystyki() : void{
    this.statystykiService.DajStatystyki().subscribe(res => {
      this.statystyki = res;
      console.log(this.statystyki);
    })
  }

  getKluby(): void {
    this.klubyService.DajKluby().subscribe(res => {
      this.archiwalneKluby = res;
      console.log(this.archiwalneKluby);
    })
  }

  DodajPilkarza(): void {
    console.log(this.pilkarz);
  }
}
