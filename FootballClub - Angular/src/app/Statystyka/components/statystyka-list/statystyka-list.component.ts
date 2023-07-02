import { Component, OnInit } from '@angular/core';
import { StatystykaService } from 'src/app/Services/statystyka.service';
import { Statystyka } from '../../Models/statystyka.model';

@Component({
  selector: 'app-statystyka-list',
  templateUrl: './statystyka-list.component.html',
  styleUrls: ['./statystyka-list.component.css']
})
export class StatystykaListComponent implements OnInit {

  statystyki: Statystyka[] = [];
  displayedColumns: string[] = ['Mecz', 'Gole', 'Asysty', 'Zolte Kartki', 'Czerwone Kartki', 'Przebiegniety Dystans', 'Ocena'];

  constructor(private statystykaService: StatystykaService) {
    this.getStatystyki();
  }

  ngOnInit(): void {
    this.getStatystyki();
  }

  getStatystyki() {
    this.statystykaService.DajStatystyki().subscribe(res => {
      this.statystyki = res;
      console.log(this.statystyki);
    })
  }
}
