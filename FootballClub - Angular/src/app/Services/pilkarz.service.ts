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

  /*
  getOne(id: number): Observable<Pilkarz> {
    return this.httpClient.get<Pilkarz>(environment.url + '/' + id);
  }

  delete(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(environment.url + '/' + id);
  }

  post(req: PilkarzRequest): Observable<Pilkarz> {
    return this.httpClient.post<Pilkarz>(environment.url, req);
  }

  put(id: number, req: PilkarzRequest): Observable<Pilkarz> {
    return this.httpClient.put<Pilkarz>(environment.url + '/' + id, req);
  }
  */
}
