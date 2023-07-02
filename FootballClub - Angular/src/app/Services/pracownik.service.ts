import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Pracownik } from '../Pracownik/Models/pracownik.model';
import { Zarzad } from '../Zarzad/Models/zarzad.model';

@Injectable({
  providedIn: 'root'
})
export class PracownikService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(private httpClient: HttpClient) { }

  DajPracownikow(): Observable<Pracownik[]> {
    return this.httpClient.get<Pracownik[]>(environment.url + 'Pracownicy');
  }

  ZmienFunkcjePracownika(IdPracownik: number, funkcja: string): Observable<Zarzad> {
    return this.httpClient.put<Zarzad>(environment.url + 'Pracownicy/ZmienFunkcjePracownika/' + IdPracownik, funkcja);
  }
}
