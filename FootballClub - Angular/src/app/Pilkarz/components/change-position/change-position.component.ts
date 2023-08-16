import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Pilkarz } from '../../Models/pilkarz.model';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-change-position',
  templateUrl: './change-position.component.html',
  styleUrls: ['./change-position.component.css']
})
export class ChangePositionComponent implements OnInit {

  pilkarz!: FormGroup;
  pilkarze!: Pilkarz[];
  pozycje: string[] = ['Bramkarz', 'Boczny Obrońca', 'Środkowy Obrońca', 'Obrońca',
    'Boczny Pomocnik', 'Środkowy Pomocnik', 'Defensywny Pomocnik', 'Ofensywny Pomocnik',
    "Napastnik", "Środkowy Napastnik", "Skrzydłowy"];

  constructor(private pilkarzService: PilkarzService, private router: Router) {
    this.pilkarz = new FormGroup({
      idPilkarz: new FormControl('', Validators.required),
      pozycja: new FormControl('', Validators.required),
    });
    this.getPilkarze();
  }

  ngOnInit(): void {
    this.getPilkarze();
  }

  getPilkarze(): void {
    this.pilkarzService.DajPilkarzy().subscribe(res => {
      this.pilkarze = res
    })
  }

  ZmienPozycjePilkarza(): void {
    console.log(this.pilkarz.value.pozycja);
    console.log(this.pilkarz.value);
    this.pilkarzService.ZmienPozycjePilkarza(this.pilkarz.value.idPilkarz, this.pilkarz.value.pozycja).subscribe(res => {
      console.log("Zmieniono pozycję piłkarza");
      this.getBack();
    })
  }

  getBack(): void {
    this.router.navigateByUrl("/Pilkarze");
  }



}
