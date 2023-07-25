import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Statystyka } from '../Statystyka/Models/statystyka.model';

@Injectable({
  providedIn: 'root'
})
export class StatystykaService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(private httpClient: HttpClient) { }

  DodajStatystyke(statystyka: any): Observable<void> {
    return this.httpClient.post<void>(environment.url + "Statystyki/DodajStatystke", statystyka, this.httpOptions);
  }

  EdytujStatystyke(id: string, statystyka: any): Observable<void> {
    return this.httpClient.put<void>(environment.url + "Statystyki/EdytujStatystyke/" + id, statystyka, this.httpOptions);
  }

  DeleteStatystyke(id: string): Observable<void> {
    return this.httpClient.delete<void>(environment.url + "Statystyki/UsunStatystyke/" + id, this.httpOptions);
  }


  DajStatystyki(): Observable<Statystyka[]> {
    return this.httpClient.get<Statystyka[]>(environment.url + 'Statystyki/DajStatystyki', this.httpOptions);
  }

  DajStatystyke(id: string): Observable<Statystyka> {
    return this.httpClient.get<Statystyka>(environment.url + 'Statystyki/DajStatystyke/' + id, this.httpOptions);
  }

  DajStatystykeMeczu(mecz: string): Observable<Statystyka[]> {
    return this.httpClient.get<Statystyka[]>(environment.url + 'Statystyki/DajStatystykeMeczu/' + mecz, this.httpOptions);
  }

  DajStatystkiZoltejKartki(): Observable<Statystyka[]> {
    return this.httpClient.get<Statystyka[]>(environment.url + 'Statystyki/DajStatystkiZoltejKartki', this.httpOptions);
  }

  DajStatystykiCzerwonychKartek(): Observable<Statystyka[]> {
    return this.httpClient.get<Statystyka[]>(environment.url + 'Statystyki/DajStatystykiCzerwonychKartek', this.httpOptions);
  }

  DajStatystykiNajlepszaOcena(): Observable<Statystyka[]> {
    return this.httpClient.get<Statystyka[]>(environment.url + 'Statystyki/DajStatystykiNajlepszaOcena', this.httpOptions);
  }
}
