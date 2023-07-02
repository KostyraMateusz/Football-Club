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

  DajStatystyki(): Observable<Statystyka[]> {
    return this.httpClient.get<Statystyka[]>(environment.url + 'Statystyki/DajStatystyki');
  }

  DajStatystykeMeczu(mecz: string): Observable<Statystyka[]> {
    return this.httpClient.get<Statystyka[]>(environment.url + 'Statystyki/DajStatystykeMeczu/' + mecz);
  }

  DajStatystkiZoltejKartki(): Observable<Statystyka[]> {
    return this.httpClient.get<Statystyka[]>(environment.url + 'Statystyki/DajStatystkiZoltejKartki');
  }

  DajStatystykiCzerwonychKartek(): Observable<Statystyka[]> {
    return this.httpClient.get<Statystyka[]>(environment.url + 'Statystyki/DajStatystykiCzerwonychKartek');
  }

  DajStatystykiNajdluzszePrzebiegnieteDystanse(): Observable<Statystyka[]> {
    return this.httpClient.get<Statystyka[]>(environment.url + 'Statystyki/DajStatystykiNajdluzszePrzebiegnieteDystanse');
  }
}
