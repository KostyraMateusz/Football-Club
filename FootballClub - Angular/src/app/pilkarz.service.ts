import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PilkarzResponse } from './Pilkarz/Models/pilkarz-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PilkarzService {
  private readonly url: string = 'http://localhost:5035/api/Pilkarze';

  constructor(private httpClient: HttpClient) { }

  DajPilkarzy(): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(this.url+ '/DajPilkarzy');
  }

  DajArchiwalneKlubyPilkarza(idPilkarz: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(this.url + '/DajArchiwalneKlubyPilkarza/' + idPilkarz);
  }

  DajStatystykePilkarza(idStatystyka: number, idPilkarz: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(this.url + '/DajStatystykePilkarza/' +idStatystyka + ',' + idPilkarz);
  }

  DajStatystykiPilkarza(idPilkarz: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(this.url + '/DajStatystykiPilkarza/' + idPilkarz);
  }

  DajNajlepszeStatystykiPilkarza(idPilkarz: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(this.url + '/DajNajlepszeStatystykiPilkarza/' + idPilkarz);
  }

  DajPilkarzyBezKlubu(): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(this.url + '/DajPilkarzyBezKlubu');
  }

  ZmienPozycjePilkarza(idPilkarz: number, pozycja: string): Observable<PilkarzResponse> {
    return this.httpClient.put<PilkarzResponse>(this.url + '/' + idPilkarz, pozycja);
  }

  /*
  getOne(id: number): Observable<PilkarzResponse> {
    return this.httpClient.get<PilkarzResponse>(this.url + '/' + id);
  }

  delete(id: number): Observable<boolean> {
    return this.httpClient.delete<boolean>(this.url + '/' + id);
  }

  post(req: PilkarzRequest): Observable<PilkarzResponse> {
    return this.httpClient.post<PilkarzResponse>(this.url, req);
  }

  put(id: number, req: PilkarzRequest): Observable<PilkarzResponse> {
    return this.httpClient.put<PilkarzResponse>(this.url + '/' + id, req);
  }
  */
}
