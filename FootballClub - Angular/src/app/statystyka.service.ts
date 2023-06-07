import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StatystykaResponse } from './Statystyka/Models/statystyka-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StatystykaService {

  private readonly url: string = 'http://localhost:5035/api/Statystyka';

  constructor(private httpClient: HttpClient) { }

  DajDajStatystykiZarzady(): Observable<StatystykaResponse[]> {
    return this.httpClient.get<StatystykaResponse[]>(this.url+ '/DajZarzady');
  }

  DajStatystykeMeczu(mecz: string): Observable<StatystykaResponse[]> {
    return this.httpClient.get<StatystykaResponse[]>(this.url+ '/DajStatystykeMeczu/' + mecz);
  }

  DajStatystkiZoltejKartki(): Observable<StatystykaResponse[]> {
    return this.httpClient.get<StatystykaResponse[]>(this.url+ '/DajStatystkiZoltejKartki');
  }

  DajStatystykiCzerwonychKartek(): Observable<StatystykaResponse[]> {
    return this.httpClient.get<StatystykaResponse[]>(this.url+ '/DajStatystykiCzerwonychKartek');
  }

  DajStatystykiNajdluzszePrzebiegnieteDystanse(): Observable<StatystykaResponse[]> {
    return this.httpClient.get<StatystykaResponse[]>(this.url+ '/DajStatystykiNajdluzszePrzebiegnieteDystanse');
  }
}
