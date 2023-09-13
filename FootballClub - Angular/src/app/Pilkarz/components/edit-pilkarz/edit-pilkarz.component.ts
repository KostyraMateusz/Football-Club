import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Klub } from 'src/app/Klub/Models/klub.model';
import { KlubService } from 'src/app/Services/klub.service';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { StatystykaService } from 'src/app/Services/statystyka.service';
import { Statystyka } from 'src/app/Statystyka/Models/statystyka.model';
import { Pilkarz } from '../../Models/pilkarz.model';

@Component({
  selector: 'app-edit-pilkarz',
  templateUrl: './edit-pilkarz.component.html',
  styleUrls: ['./edit-pilkarz.component.css']
})
export class EditPilkarzComponent implements OnInit {


  statystyki: Statystyka[] = [];
  archiwalneKluby: Klub[] = [];
  kluby: Klub[] = [];
  obecnyKlubReal!: Klub;
  idKlub!: string;
  id!: string;
  pilkarz!: FormGroup;
  znalezionyPilkarz?: Pilkarz;
  pozycje: string[] = ['BR', 'ŚO', 'PO', 'LO', 'CPS', 'CLS', 'ŚPD', 'ŚP', 'ŚPO', 'LP', 'PP', 'LS', 'PS', 'ŚN', 'N']

  constructor(private pilkarzService: PilkarzService, private klubyService: KlubService, private statystykiService: StatystykaService,
    private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder, private router: Router) {
    this.getStatystyki();
    this.getKluby();

    this.activatedRoute.params.subscribe(res => {
      this.id = res['id'];
    })

    if (this.id !== '') {
      this.pilkarzService.DajPilkarza(this.id).subscribe(res => {
        this.znalezionyPilkarz = res;
        console.log(this.znalezionyPilkarz);
        this.pilkarz.patchValue(res);
      })
    }

    this.pilkarz = this.formBuilder.group({
      imie: this.formBuilder.control(this.znalezionyPilkarz?.imie, Validators.required),
      nazwisko: this.formBuilder.control(this.znalezionyPilkarz?.nazwisko, Validators.required),
      pesel: this.formBuilder.control(this.znalezionyPilkarz?.wynagrodzenie, Validators.required),
      wiek: this.formBuilder.control(this.znalezionyPilkarz?.wiek, Validators.required),
      pozycja: this.formBuilder.control(this.znalezionyPilkarz?.pozycja, Validators.required),
      archiwalneKluby: this.formBuilder.control(this.znalezionyPilkarz?.archiwalneKluby, Validators.required),
      wynagrodzenie: this.formBuilder.control(this.znalezionyPilkarz?.wynagrodzenie, Validators.required),
      idKlub: this.formBuilder.control(this.znalezionyPilkarz?.idKlub, Validators.required)
    });


  }

  getBack(): void {
    this.router.navigateByUrl("/Pilkarze");
  }


  ngOnInit(): void {
    this.getStatystyki();
    this.getKluby();
    console.log(this.znalezionyPilkarz);
  }

  getStatystyki(): void {
    this.statystykiService.DajStatystyki().subscribe(res => {
      this.statystyki = res;
    })
  }

  getKluby(): void {
    this.klubyService.DajKluby().subscribe(res => {
      this.archiwalneKluby = res;
      this.kluby = res;
    })
  }


  EdytujPilkarza(): void {
    console.log(this.pilkarz.value);
    if (this.pilkarz.value.idKlub) {
      this.pilkarzService.EdytujPilkarza(this.id, this.pilkarz.value.idKlub, this.pilkarz.value).subscribe(res => {
        console.log("Edytowano Piłkarza");
        this.router.navigateByUrl("/Pilkarze");
      })
    }

  }


}
