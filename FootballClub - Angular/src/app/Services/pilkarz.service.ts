import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Pilkarz } from '../Pilkarz/Models/pilkarz.model';
import { Statystyka } from '../Statystyka/Models/statystyka.model';
import { Klub } from '../Klub/Models/klub.model';

@Injectable({
  providedIn: 'root'
})
export class PilkarzService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(private httpClient: HttpClient) { }

  DodajPilkarza(pilkarz: any): Observable<void> {
    return this.httpClient.post<void>(environment.url + "Pilkarze/DodajPilkarza", pilkarz, this.httpOptions);
  }

  EdytujPilkarza(id: string, pilkarz: any): Observable<void> {
    return this.httpClient.put<void>(environment.url + "Pilkarze/EdytujPilkarza/" + id, pilkarz, this.httpOptions);
  }

  DeletePilkarza(id: string): Observable<void> {
    return this.httpClient.delete<void>(environment.url + "Pilkarze/UsunPilkarza/" + id, this.httpOptions);
  }


  DajPilkarzy(): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Pilkarze/DajPilkarzy', this.httpOptions);
  }

  DajArchiwalneKlubyPilkarza(idPilkarz: string): Observable<Klub[]> {
    return this.httpClient.get<Klub[]>(environment.url + 'Pilkarze/DajArchiwalneKlubyPilkarza/' + idPilkarz, this.httpOptions);
  }

  DajStatystykePilkarza(idStatystyka: string, idPilkarz: string): Observable<Statystyka> {
    return this.httpClient.get<Statystyka>(environment.url + 'Pilkarze/DajStatystykePilkarza/' + idStatystyka + ',' + idPilkarz, this.httpOptions);
  }

  DajStatystykiPilkarza(idPilkarz: string): Observable<Statystyka[]> {
    return this.httpClient.get<Statystyka[]>(environment.url + 'Pilkarze/DajStatystykiPilkarza/' + idPilkarz, this.httpOptions);
  }

  DajNajlepszeStatystykiPilkarza(idPilkarz: string): Observable<Statystyka[]> {
    return this.httpClient.get<Statystyka[]>(environment.url + 'Pilkarze/DajNajlepszeStatystykiPilkarza/' + idPilkarz, this.httpOptions);
  }

  DajPilkarzyBezKlubu(): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Pilkarze/DajPilkarzyBezKlubu', this.httpOptions);
  }

  ZmienPozycjePilkarza(idPilkarz: string, pozycja: string): Observable<void> {
    return this.httpClient.put<void>(environment.url + 'Pilkarze/ZmienPozycjePilkarza/' + idPilkarz, pozycja, this.httpOptions);
  }

}
