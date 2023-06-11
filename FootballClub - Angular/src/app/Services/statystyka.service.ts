import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StatystykaResponse } from '../Statystyka/Models/statystyka-response';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StatystykaService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(private httpClient: HttpClient) { }

  DajDajStatystykiZarzady(): Observable<StatystykaResponse[]> {
    return this.httpClient.get<StatystykaResponse[]>(environment.url + '/DajZarzady');
  }

  DajStatystykeMeczu(mecz: string): Observable<StatystykaResponse[]> {
    return this.httpClient.get<StatystykaResponse[]>(environment.url + '/DajStatystykeMeczu/' + mecz);
  }

  DajStatystkiZoltejKartki(): Observable<StatystykaResponse[]> {
    return this.httpClient.get<StatystykaResponse[]>(environment.url + '/DajStatystkiZoltejKartki');
  }

  DajStatystykiCzerwonychKartek(): Observable<StatystykaResponse[]> {
    return this.httpClient.get<StatystykaResponse[]>(environment.url + '/DajStatystykiCzerwonychKartek');
  }

  DajStatystykiNajdluzszePrzebiegnieteDystanse(): Observable<StatystykaResponse[]> {
    return this.httpClient.get<StatystykaResponse[]>(environment.url + '/DajStatystykiNajdluzszePrzebiegnieteDystanse');
  }
}
