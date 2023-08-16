import { Component, OnInit } from '@angular/core';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { Pilkarz } from '../../Models/pilkarz.model';

@Component({
  selector: 'app-pilkarz-list',
  templateUrl: './pilkarz-list.component.html',
  styleUrls: ['./pilkarz-list.component.css']
})
export class PilkarzListComponent implements OnInit {

  pilkarze: Pilkarz[] = [];
  displayedColumns: string[] = ['Imie', 'Nazwisko', 'Wiek', 'Pozycja', 'Wynagrodzenie', 'Statystyki', 'ArchiwalneKluby',
    'Edytuj', 'Usuń'];

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

  usunPilkarza(idPilkarza: string): void {

  }
}
