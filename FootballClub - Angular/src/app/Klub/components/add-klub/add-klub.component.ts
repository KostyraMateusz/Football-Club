import { Component, OnInit } from '@angular/core';
import { KlubRequest } from '../../Models/klub-request';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PilkarzRequest } from 'src/app/Pilkarz/Models/pilkarz-request';
import { KlubService } from 'src/app/Services/klub.service';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { ZarzadRequest } from 'src/app/Zarzad/Models/zarzad-request';

@Component({
  selector: 'app-add-klub',
  templateUrl: './add-klub.component.html',
  styleUrls: ['./add-klub.component.css']
})
export class AddKlubComponent implements OnInit {

  klub = new FormGroup({
    Nazwa: new FormControl('', Validators.required),
    Stadion: new FormControl('', Validators.required),
    ArchiwalniPilkarze: new FormControl('', Validators.required),
    ObecniPilkarze: new FormControl('', Validators.required),
    Zarzad: new FormControl('', Validators.required),
  });

  pilkarze: PilkarzRequest[] = [];
  zarzady: ZarzadRequest[] = [];


  constructor(private klubService: KlubService, private pilkarzService: PilkarzService) {
    this.getPilkarze();
  }

  ngOnInit(): void {
    this.getPilkarze();
  }


  getPilkarze(): void {
    this.pilkarzService.DajPilkarzy().subscribe(res => {
      this.pilkarze = res;
      console.log(this.pilkarze);
    })
  }

  getZarzady(): void {
    
  }

  DodajKlub(): void {
    console.log(this.klub);
  }
}
