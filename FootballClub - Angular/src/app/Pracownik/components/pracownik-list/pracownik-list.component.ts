import { Component, OnInit } from '@angular/core';
import { PracownikResponse } from '../../Models/pracownik-response';
import { PracownikService } from 'src/app/Services/pracownik.service';

@Component({
  selector: 'app-pracownik-list',
  templateUrl: './pracownik-list.component.html',
  styleUrls: ['./pracownik-list.component.css']
})
export class PracownikListComponent implements OnInit {

  pracownicy: PracownikResponse[] = [];
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
