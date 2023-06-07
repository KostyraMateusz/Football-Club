import { Component, inject } from '@angular/core';
import { PilkarzResponse } from './Models/pilkarz-response';
import { PilkarzService } from '../pilkarz.service';

@Component({
  selector: 'app-pilkarz',
  templateUrl: './pilkarz.component.html',
  styleUrls: ['./pilkarz.component.css']
})
export class PilkarzComponent {
  pilkarze: PilkarzResponse[] = [];

  private osobyService: PilkarzService = inject(PilkarzService);

  constructor() {
    this.osobyService.DajPilkarzy().subscribe({
      next: (res) => {
        this.pilkarze = res;
      }
    });
  }
  
}
