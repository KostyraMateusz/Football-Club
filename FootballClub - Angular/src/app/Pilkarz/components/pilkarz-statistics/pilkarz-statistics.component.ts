import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Pilkarz } from '../../Models/pilkarz.model';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { Router } from '@angular/router';
import { Statystyka } from 'src/app/Statystyka/Models/statystyka.model';

@Component({
  selector: 'app-pilkarz-statistics',
  templateUrl: './pilkarz-statistics.component.html',
  styleUrls: ['./pilkarz-statistics.component.css']
})
export class PilkarzStatisticsComponent implements OnInit {

  pilkarz!: FormGroup;
  pilkarze!: Pilkarz[];
  statystyki!: Statystyka[];

  constructor(private pilkarzService: PilkarzService, private router: Router) {
    this.pilkarz = new FormGroup({
      idPilkarz: new FormControl('', Validators.required)
    });
    this.getPilkarze();
  }

  ngOnInit(): void {
    this.getPilkarze();
  }

  getPilkarze(): void {
    this.pilkarzService.DajPilkarzy().subscribe(res => {
      this.pilkarze = res;
    })
  }

  getBack(): void {
    this.router.navigateByUrl("/Pilkarze")
  }

  DajStatystkiPilkarza(): void {
    this.pilkarzService.DajStatystykiPilkarza(this.pilkarz.value.idPilkarz).subscribe(res => {
      console.log(res);
      this.statystyki = res
    })
  }

}
