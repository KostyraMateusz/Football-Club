import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Pilkarz } from 'src/app/Pilkarz/Models/pilkarz.model';
import { KlubService } from 'src/app/Services/klub.service';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { ZarzadService } from 'src/app/Services/zarzad.service';
import { Zarzad } from 'src/app/Zarzad/Models/zarzad.model';

@Component({
  selector: 'app-add-klub',
  templateUrl: './add-klub.component.html',
  styleUrls: ['./add-klub.component.css']
})
export class AddKlubComponent implements OnInit {

  pilkarze: Pilkarz[] = [];
  zarzady: Zarzad[] = [];
  klub!: FormGroup;

  constructor(private klubService: KlubService, private pilkarzService: PilkarzService, private zarzadService: ZarzadService,
    private formBuilder: FormBuilder) {
    this.getPilkarze();
    this.getZarzady();
  }

  ngOnInit(): void {
    this.getPilkarze();
    this.getZarzady();
    this.klub = new FormGroup({
      Nazwa: new FormControl('', Validators.required),
      Stadion: new FormControl('', Validators.required),
      Trofea: new FormControl('', Validators.required),
      ArchiwalniPilkarze: new FormControl('', Validators.required),
      ObecniPilkarze: new FormControl('', Validators.required),
      Zarzad: new FormControl('', Validators.required),
    });
  }


  getPilkarze(): void {
    this.pilkarzService.DajPilkarzy().subscribe(res => {
      this.pilkarze = res;
      //console.log(this.pilkarze);
    })
  }

  getZarzady(): void {
    this.zarzadService.DajZarzady().subscribe(res => {
      this.zarzady = res;
      //console.log(this.zarzady);
    })
  }

  DodajKlub(): void {
    console.log(this.klub.value);
    this.klub.value.Zarzad = null;
    this.klubService.DodajKlub(this.klub.value).subscribe(res => {
      console.log("Klub został dodany");
    })
  }
}
