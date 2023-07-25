import { Component, OnInit } from '@angular/core';
import { StatystykaService } from 'src/app/Services/statystyka.service';
import { Statystyka } from '../../Models/statystyka.model';

@Component({
  selector: 'app-statystyka-list',
  templateUrl: './statystyka-list.component.html',
  styleUrls: ['./statystyka-list.component.css']
})
export class StatystykaListComponent implements OnInit {

  statystykaNajIsShown: boolean = false;
  statystykaZoltejIsShown: boolean = false;
  statystykaCzeerwoenjIsShown: boolean = false;
  statystyki: Statystyka[] = [];
  statystkiNajlepsze: Statystyka[] = [];
  statystykiZoltej: Statystyka[] = [];
  statystykiCzerwonej: Statystyka[] = [];
  displayedColumns: string[] = ['Pilkarz', 'Mecz', 'Gole', 'Asysty', 'Zolte Kartki', 'Czerwone Kartki', 'Przebiegniety Dystans', 'Ocena', "Edytuj", "Usuń"];

  constructor(private statystykaService: StatystykaService) {
    this.getStatystyki();
  }

  ngOnInit(): void {
    this.getStatystyki();
  }

  getStatystyki(): void {
    this.statystykaService.DajStatystyki().subscribe(res => {
      this.statystyki = res;
      console.log(this.statystyki);
    })
  }

  usunStatysyke(id: string): void {
    this.statystykaService.DeleteStatystyke(id).subscribe(res => {
      console.log("Usunieto statystykę.");
      this.getStatystyki();
    })
  }


  DajNajlepszeStatystyki(): void {
    this.statystykaService.DajStatystykiNajlepszaOcena().subscribe(res => {
      this.statystkiNajlepsze = res;
      console.log(this.statystkiNajlepsze);
      this.statystyki = this.statystkiNajlepsze;
    })
  }

  DajStatystykiZolteKartki(): void {
    this.statystykaService.DajStatystkiZoltejKartki().subscribe(res => {
      this.statystykiZoltej = res;
      console.log(this.statystykiZoltej);
      this.statystyki = this.statystykiZoltej;
    })
  }

  DajStatystykiCzerwonejKartki(): void {
    this.statystykaService.DajStatystykiCzerwonychKartek().subscribe(res => {
      this.statystykiCzerwonej = res;
      console.log(this.statystykiCzerwonej);
      this.statystyki = this.statystykiCzerwonej;
    })
  }
}
