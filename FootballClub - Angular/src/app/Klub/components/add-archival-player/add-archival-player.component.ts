import { Component, OnInit } from '@angular/core';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { Klub } from '../../Models/klub.model';
import { Pilkarz } from 'src/app/Pilkarz/Models/pilkarz.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { KlubService } from 'src/app/Services/klub.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-archival-player',
  templateUrl: './add-archival-player.component.html',
  styleUrls: ['./add-archival-player.component.css']
})
export class AddArchivalPlayerComponent implements OnInit {

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
  }

  ngOnInit(): void {
    this.DajKlubyDoWyboru();
    this.DajPilkarzyDoWyboru();
  }

  DajKlubyDoWyboru(): void {
    this.klubService.DajKluby().subscribe(res => {
      this.kluby = res.filter(k => k.nazwa !== "Real Madryt");
      console.log(this.kluby);
    })
  }

  DajPilkarzyDoWyboru(): void {
    this.pilkarzService.DajPilkarzy().subscribe(res => {
      this.pilkarze = res;
      console.log(this.pilkarze);
    })
  }

  DodajPilkarzaDoArchiwalnych(): void {
    this.wybranyKlub = this.kluby.find(k => k.idKlub === this.form.value.idKlub);
    this.wybranyPilkarz = this.pilkarze.find(p => p.idPilkarz === this.form.value.idPilkarz);
    console.log(this.wybranyKlub);
    console.log(this.wybranyPilkarz);
    if (this.wybranyPilkarz && this.wybranyKlub) {
      if (this.wybranyKlub?.obecniPilkarze?.includes(this.wybranyPilkarz)) {
        console.log("Piłkarz już należy do archiwalnych piłkarzy");
      } else {
        this.klubService.DodajPilkarzaDoArchiwalnych(this.wybranyPilkarz, this.form.value.idKlub).subscribe(res => {
          console.log("Dodano piłkarza do obecnych");
          this.router.navigateByUrl("Kluby/InneKluby")
        })
      }
    } else {
      console.log("Błąd! Sprawdź klub lub piłkarza");
    }
  }
}
