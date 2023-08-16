import { Component, OnInit } from '@angular/core';
import { KlubService } from 'src/app/Services/klub.service';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { ZarzadService } from 'src/app/Services/zarzad.service';
import { Klub } from '../../Models/klub.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Zarzad } from 'src/app/Zarzad/Models/zarzad.model';
import { Pilkarz } from 'src/app/Pilkarz/Models/pilkarz.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-klub',
  templateUrl: './edit-klub.component.html',
  styleUrls: ['./edit-klub.component.css']
})
export class EditKlubComponent implements OnInit {

  zarzady!: Zarzad[];
  pilkarze!: Pilkarz[];
  foundKlub!: Klub;
  klub!: FormGroup;
  id: string = "";


  ngOnInit(): void {
    this.getKlub();
    this.getPilkarze();
    this.getZarzady();

    this.klub = new FormGroup({
      nazwa: new FormControl('', Validators.required),
      stadion: new FormControl('', Validators.required),
      trofea: new FormControl('', Validators.required),
      archiwalniPilkarze: new FormControl('', Validators.required),
      obecniPilkarze: new FormControl('', Validators.required),
      zarzad: new FormControl('', Validators.required),
    });
  }

  constructor(private klubService: KlubService, private pilkarzService: PilkarzService, private zarzadService: ZarzadService, private activatedRoute: ActivatedRoute) {
    activatedRoute.params.subscribe(res => {
      this.id = res['id'];
    })
    this.getKlub();
    this.getPilkarze();
    this.getZarzady();
  }

  getPilkarze(): void {
    this.pilkarzService.DajPilkarzy().subscribe(res => {
      this.pilkarze = res;
    })
  }

  getZarzady(): void {
    this.zarzadService.DajZarzady().subscribe(res => {
      this.zarzady = res;
    })
  }

  getKlub(): void {
    this.klubService.DajKlub(this.id).subscribe(res => {
      this.foundKlub = res;
      //this.klub.patchValue(res);
      this.klub.value.Nazwa = this.foundKlub.nazwa;
      this.klub.value.Stadion = this.foundKlub.stadion;
      this.klub.value.Trofea = this.foundKlub.trofea;
      this.klub.value.ObecniPilkarze = this.foundKlub.obecniPilkarze;
      this.klub.value.ArchiwalniPilkarze = this.foundKlub.archiwalniPilkarze;
      this.klub.value.Zarzad = this.foundKlub.zarzad;
      console.log(this.klub.value);
    })
  }

  EdytujKlub(): void {

  }
}
