import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PilkarzResponse } from '../Pilkarz/Models/pilkarz-response';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PilkarzService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(private httpClient: HttpClient) { }

  DajPilkarzy(): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(environment.url + 'Pilkarze/DajPilkarzy');
  }

  DajArchiwalneKlubyPilkarza(idPilkarz: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(environment.url + 'Pilkarze/DajArchiwalneKlubyPilkarza/' + idPilkarz);
  }

  DajStatystykePilkarza(idStatystyka: number, idPilkarz: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(environment.url + 'Pilkarze/DajStatystykePilkarza/' + idStatystyka + ',' + idPilkarz);
  }

  DajStatystykiPilkarza(idPilkarz: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(environment.url + 'Pilkarze/DajStatystykiPilkarza/' + idPilkarz);
  }

  DajNajlepszeStatystykiPilkarza(idPilkarz: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(environment.url + 'Pilkarze/DajNajlepszeStatystykiPilkarza/' + idPilkarz);
  }

  DajPilkarzyBezKlubu(): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(environment.url + 'Pilkarze/DajPilkarzyBezKlubu');
  }

  ZmienPozycjePilkarza(idPilkarz: number, pozycja: string): Observable<PilkarzResponse> {
    return this.httpClient.put<PilkarzResponse>(environment.url + '/' + idPilkarz, pozycja);
  }

  /*
  getOne(id: number): Observable<PilkarzResponse> {
    return this.httpClient.get<PilkarzResponse>(environment.url + '/' + id);
  }

  delete(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(environment.url + '/' + id);
  }

  post(req: PilkarzRequest): Observable<PilkarzResponse> {
    return this.httpClient.post<PilkarzResponse>(environment.url, req);
  }

  put(id: number, req: PilkarzRequest): Observable<PilkarzResponse> {
    return this.httpClient.put<PilkarzResponse>(environment.url + '/' + id, req);
  }
  */
}
