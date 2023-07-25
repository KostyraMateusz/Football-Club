import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Pilkarz } from '../Pilkarz/Models/pilkarz.model';

@Injectable({
  providedIn: 'root'
})
export class PilkarzService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(private httpClient: HttpClient) { }

  DodajPilkarza(pilkarza: any): Observable<void> {
    return this.httpClient.post<void>(environment.url + "Pilkarze/DodajPilkarza", pilkarza);
  }

  EdytujPilkarza(id: string, pilkarza: any): Observable<void> {
    return this.httpClient.put<void>(environment.url + "Pilkarze/EdytujPilkarza/" + id, pilkarza);
  }

  DeletePilkarza(id: string): Observable<void> {
    return this.httpClient.delete<void>(environment.url + "Pilkarze/UsunPilkarza/" + id);
  }


  DajPilkarzy(): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Pilkarze/DajPilkarzy');
  }

  DajArchiwalneKlubyPilkarza(idPilkarz: number): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Pilkarze/DajArchiwalneKlubyPilkarza/' + idPilkarz);
  }

  DajStatystykePilkarza(idStatystyka: number, idPilkarz: number): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Pilkarze/DajStatystykePilkarza/' + idStatystyka + ',' + idPilkarz);
  }

  DajStatystykiPilkarza(idPilkarz: number): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Pilkarze/DajStatystykiPilkarza/' + idPilkarz);
  }

  DajNajlepszeStatystykiPilkarza(idPilkarz: number): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Pilkarze/DajNajlepszeStatystykiPilkarza/' + idPilkarz);
  }

  DajPilkarzyBezKlubu(): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Pilkarze/DajPilkarzyBezKlubu');
  }

  ZmienPozycjePilkarza(idPilkarz: number, pozycja: string): Observable<Pilkarz> {
    return this.httpClient.put<Pilkarz>(environment.url + '/' + idPilkarz, pozycja);
  }
}
