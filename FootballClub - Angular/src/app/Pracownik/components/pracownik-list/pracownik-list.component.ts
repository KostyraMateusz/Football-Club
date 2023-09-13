import { AfterContentChecked, AfterViewInit, Component, OnInit } from '@angular/core';
import { PracownikService } from 'src/app/Services/pracownik.service';
import { Pracownik } from '../../Models/pracownik.model';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort, Sort } from '@angular/material/sort';
import { LiveAnnouncer } from '@angular/cdk/a11y';

@Component({
  selector: 'app-pracownik-list',
  templateUrl: './pracownik-list.component.html',
  styleUrls: ['./pracownik-list.component.css']
})
export class PracownikListComponent implements OnInit, AfterViewInit, AfterContentChecked {

  sort!: MatSort;
  paginator!: MatPaginator;
  dataSource: Pracownik[] = [];
  displayedColumns: string[] = ['Imie', 'Nazwisko', 'PESEL', 'Wiek', 'Wykonywana Funkcja', 'Wynagrodzenie', 'Edytuj', 'Usuń'];
  datasource!: MatTableDataSource<Pracownik>;

  constructor(private pracownikService: PracownikService, private router: Router, private _liveAnnouncer: LiveAnnouncer) {
    this.getPracownicy();
    this.datasource = new MatTableDataSource(this.dataSource);
  }
  ngAfterContentChecked(): void {
    this.datasource.sort = this.sort
  }

  ngAfterViewInit(): void {
    this.datasource.sort = this.sort;
    this.datasource.paginator = this.paginator;
  }

  ngOnInit(): void {
    this.getPracownicy();
    this.datasource = new MatTableDataSource(this.dataSource);
    console.log(this.dataSource);
  }


  announceSortChange(sortState: any): void {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  getPracownicy() {
    this.pracownikService.DajPracownikow().subscribe(res => {
      this.dataSource = res;
      console.log(this.dataSource);
    })
  }

  usunPracownika(idPracownik: string): void {
    this.pracownikService.DeletePracownika(idPracownik).subscribe(res => {
      console.log("Usunięto pracownika");
      this.router.navigateByUrl("/Pracownicy");
    })
  }

  PrzejdzDoDodaj(): void {
    this.router.navigateByUrl("Pracownicy/DodajPracownika");
  }

  ZmienPensjePracownika(): void {
    this.router.navigateByUrl("Pracownicy/ZmienPensjePracownika");
  }

  ZmienWiekPracownika(): void {
    this.router.navigateByUrl("Pracownicy/ZmienWiekPracownika");
  }

  ZmienFunkcjePracownika(): void {
    this.router.navigateByUrl("Pracownicy/ZmienFunkcjePracownika");
  }

}