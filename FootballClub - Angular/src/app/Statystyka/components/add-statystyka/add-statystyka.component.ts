import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PilkarzRequest } from 'src/app/Pilkarz/Models/pilkarz-request';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { StatystykaService } from 'src/app/Services/statystyka.service';

@Component({
  selector: 'app-add-statystyka',
  templateUrl: './add-statystyka.component.html',
  styleUrls: ['./add-statystyka.component.css']
})
export class AddStatystykaComponent implements OnInit{

  pilkarze: PilkarzRequest[] = [];

  statystyka = new FormGroup({
    Mecz: new FormControl('', Validators.required),
    Gole: new FormControl('', Validators.required),
    Asysty: new FormControl('', Validators.required),
    ZolteKartki: new FormControl('', Validators.required),
    CzerwoneKartki: new FormControl('', Validators.required),
    PrzebiegnietyDystans: new FormControl('', Validators.required),
    Ocena: new FormControl('', Validators.required),
    Pilkarz: new FormControl('', Validators.required)
  });

  constructor(private statystykaService: StatystykaService, private pilkarzService: PilkarzService) {
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

  DodajStatystyke(): void {
    console.log(this.statystyka);
  }
}
