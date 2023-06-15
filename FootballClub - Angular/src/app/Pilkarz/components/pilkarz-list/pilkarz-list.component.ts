import { Component, OnInit } from '@angular/core';
import { PilkarzResponse } from '../../Models/pilkarz-response';
import { PilkarzService } from 'src/app/Services/pilkarz.service';

@Component({
  selector: 'app-pilkarz-list',
  templateUrl: './pilkarz-list.component.html',
  styleUrls: ['./pilkarz-list.component.css']
})
export class PilkarzListComponent implements OnInit {

  pilkarze: PilkarzResponse[] = [];
  displayedColumns: string[] = ['Imie', 'Nazwisko', 'Wiek', 'Pozycja', 'Wynagrodzenie', 'Statystyki', 'ArchiwalneKluby'];

  constructor(private pilkarzService: PilkarzService) {
    this.getPilkarze();
  }

  ngOnInit(): void {
    this.getPilkarze();
  }

  getPilkarze() {
    this.pilkarzService.DajPilkarzy().subscribe(res => {
      this.pilkarze = res;
      console.log(this.pilkarze);
    })
  }
}
