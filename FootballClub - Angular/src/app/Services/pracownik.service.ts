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

  DodajPracownika(pracownik: any): Observable<void> {
    return this.httpClient.post<void>(environment.url + "Pracownicy/DodajPracownika", pracownik);
  }

  EdytujPracownika(id: string, pracownik: any): Observable<void> {
    return this.httpClient.put<void>(environment.url + "Pracownicy/EdytujPracownika/" + id, pracownik);
  }

  DeletePracownika(id: string): Observable<void> {
    return this.httpClient.delete<void>(environment.url + "Pracownicy/UsunPracownika/" + id);
  }


  DajPracownikow(): Observable<Pracownik[]> {
    return this.httpClient.get<Pracownik[]>(environment.url + 'Pracownicy/DajPracownikow');
  }

  ZmienFunkcjePracownika(IdPracownik: string, funkcja: string): Observable<void> {
    return this.httpClient.put<void>(environment.url + 'Pracownicy/ZmienFunkcjePracownika/' + IdPracownik, funkcja);
  }

  ZmienPensjePracownika(IdPracownik: string, pensja: number): Observable<void> {
    return this.httpClient.put<void>(environment.url + 'Pracownicy/ZmienWynagrodzeniePracownika/' + IdPracownik, pensja);
  }

  ZmienWiekPracownika(IdPracownik: string, wiek: number): Observable<void> {
    return this.httpClient.put<void>(environment.url + 'Pracownicy/ZmienWiekPracownika/' + IdPracownik, wiek);
  }
}
