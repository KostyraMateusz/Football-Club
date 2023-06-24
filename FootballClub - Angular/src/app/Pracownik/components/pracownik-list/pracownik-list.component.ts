import { Component, OnInit } from '@angular/core';
import { PracownikService } from 'src/app/Services/pracownik.service';
import { Pracownik } from '../../Models/pracownik.model';

@Component({
  selector: 'app-pracownik-list',
  templateUrl: './pracownik-list.component.html',
  styleUrls: ['./pracownik-list.component.css']
})
export class PracownikListComponent implements OnInit {

  pracownicy: Pracownik[] = [];
  displayedColumns: string[] = ['Imie', 'Nazwisko', 'PESEL', 'Wiek', 'Wykonywana Funkcja', 'Wynagrodzenie'];

  constructor(private pracownikService: PracownikService) {
    this.getPracownicy();
  }

  ngOnInit(): void {
    this.getPracownicy();
  }

  getPracownicy() {
    this.pracownikService.DajPracownikow().subscribe(res => {
      this.pracownicy = res;
      console.log(this.pracownicy);
    })
  }
}
