import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { Pilkarz } from '../../Models/pilkarz.model';
import { ThemePalette } from '@angular/material/core';
import { Statystyka } from 'src/app/Statystyka/Models/statystyka.model';

@Component({
  selector: 'app-best-statistics',
  templateUrl: './best-statistics.component.html',
  styleUrls: ['./best-statistics.component.css']
})
export class BestStatisticsComponent implements OnInit {

  pilkarz!: FormGroup;
  pilkarze!: Pilkarz[];
  statystyki!: Statystyka[];
  color: ThemePalette = 'primary';

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

  DajNajlepszeStatystkiPilkarza(): void {
    this.pilkarzService.DajNajlepszeStatystykiPilkarza(this.pilkarz.value.idPilkarz).subscribe(res => {
      this.statystyki = res;
    })
  }

  getBack(): void {
    this.router.navigateByUrl("/Pilkarze");
  }
}
