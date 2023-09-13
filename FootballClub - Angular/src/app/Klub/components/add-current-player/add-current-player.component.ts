import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Pilkarz } from 'src/app/Pilkarz/Models/pilkarz.model';
import { KlubService } from 'src/app/Services/klub.service';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { Klub } from '../../Models/klub.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-current-player',
  templateUrl: './add-current-player.component.html',
  styleUrls: ['./add-current-player.component.css']
})
export class AddCurrentPlayerComponent implements OnInit {

  form!: FormGroup;
  pilkarze: Pilkarz[] = [];
  kluby: Klub[] = [];
  wybranyKlub?: Klub;
  wybranyPilkarz?: Pilkarz;
  constructor(private pilkarzService: PilkarzService, private klubService: KlubService, private router: Router) {
    this.form = new FormGroup({
      idKlub: new FormControl('', Validators.required),
      idPilkarz: new FormControl('', Validators.required),
    });
    this.DajKlubyDoWyboru();
    this.DajPilkarzyDoWyboru();
  }

  ngOnInit(): void {
    this.DajKlubyDoWyboru();
    this.DajPilkarzyDoWyboru();
  }

  DajKlubyDoWyboru(): void {
    this.klubService.DajKluby().subscribe(res => {
      this.kluby = res;
      console.log(this.kluby);
    })
  }

  DajPilkarzyDoWyboru(): void {
    this.pilkarzService.DajPilkarzy().subscribe(res => {
      this.pilkarze = res;
      console.log(this.pilkarze);
    })
  }

  DodajPilkarzaDoObecnych(): void {
    this.wybranyKlub = this.kluby.find(k => k.idKlub === this.form.value.idKlub);
    this.wybranyPilkarz = this.pilkarze.find(p => p.idPilkarz === this.form.value.idPilkarz);
    console.log(this.wybranyKlub);
    console.log(this.wybranyPilkarz);
    if (this.wybranyPilkarz && this.wybranyKlub) {
      if (this.wybranyKlub?.obecniPilkarze?.includes(this.wybranyPilkarz)) {
        console.log("Piłkarz już należy do obecnych piłkarzy");
      } else {
        this.klubService.DodajPilkarzaDoObecnych(this.form.value.idKlub, this.wybranyPilkarz).subscribe(res => {
          console.log("Dodano piłkarza do obecnych piłkarzy");
          this.router.navigateByUrl("Kluby/InneKluby")
        })
      }
    } else {
      console.log("Błąd! Sprawdź klub lub piłkarza");
    }
  }


  getBack(): void{
    this.router.navigateByUrl("/Kluby/InneKluby");
  }
}
