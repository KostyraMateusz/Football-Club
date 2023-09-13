import { Component } from '@angular/core';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { Pilkarz } from '../../Models/pilkarz.model';

@Component({
  selector: 'app-other-pilkarz-list',
  templateUrl: './other-pilkarz-list.component.html',
  styleUrls: ['./other-pilkarz-list.component.css']
})
export class OtherPilkarzListComponent {


  pilkarze: Pilkarz[] = [];
  displayedColumns: string[] = ['Imie', 'Nazwisko', 'Wiek', 'Pozycja', 'Wynagrodzenie', 'Klub', 'ArchiwalneKluby',
    'Edytuj', 'Usuń'];

  constructor(private pilkarzService: PilkarzService) {
    this.getPilkarze();
  }

  ngOnInit(): void {
    this.getPilkarze();
  }

  getPilkarze() {
    this.pilkarzService.DajPilkarzy().subscribe(res => {
      this.pilkarze = res.filter(p => p.klub?.nazwa !== "Real Madryt");
      console.log(this.pilkarze);
    })
  }

  usunPilkarza(idPilkarza: string): void {
    this.pilkarzService.DeletePilkarza(idPilkarza).subscribe(res => {
      console.log("Usunięto piłkarza");
      this.getPilkarze();
    })
  }
}
