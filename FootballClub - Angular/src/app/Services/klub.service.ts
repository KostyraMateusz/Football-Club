import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { KlubResponse } from '../Klub/Models/klub-response';
import { Observable } from 'rxjs';
import { PilkarzResponse } from '../Pilkarz/Models/pilkarz-response';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class KlubService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(private httpClient: HttpClient) { }

  DajKluby(): Observable<KlubResponse[]> {
    return this.httpClient.get<KlubResponse[]>(environment.url + 'Kluby/DajKluby');
  }

  DajArchiwalnegoPilkarza(IdKlubu: number, IdPilkarz: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(environment.url + '/DajArchiwalnegoPilkarza/' + IdKlubu + ',' + IdPilkarz);
  }

  DajArchiwalnychPilkarzy(IdKlubu: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(environment.url + '/DajArchiwalnychPilkarzy/' + IdKlubu);
  }

  DajObecnegoPilkarza(IdKlubu: number, IdPilkarz: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(environment.url + '/DajObecnegoPilkarza/' + IdKlubu + ',' + IdPilkarz);
  }

  DajObecnychPilkarzy(IdKlubu: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(environment.url + '/DajObecnychPilkarzy/' + IdKlubu);
  }

  DajTrofeaKlubu(IdKlubu: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(environment.url + '/DajTrofeaKlubu/' + IdKlubu);
  }

  DajStadionKlubu(IdKlubu: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(environment.url + '/DajStadionKlubu/' + IdKlubu);
  }

  // DodajPilkarzaDoObecnych(IdPilkarza: number, IdKlubu: number): Observable<KlubResponse> {
  //   return this.httpClient.post<KlubResponse>(environment.url + '/DodajPilkarzaDoObecnych/', IdPilkarza, IdKlubu);
  // }

  // UsunPilkarzaZObecnych(IdPilkarza: number, IdKlubu: number): Observable<KlubResponse> {
  //   return this.httpClient.post<KlubResponse>(environment.url + '/UsunPilkarzaZObecnych/', IdPilkarza, IdKlubu);
  // }
}
