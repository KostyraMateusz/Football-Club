import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { KlubResponse } from './Klub/Models/klub-response';
import { Observable } from 'rxjs';
import { PilkarzResponse } from './Pilkarz/Models/pilkarz-response';

@Injectable({
  providedIn: 'root'
})
export class KlubService {

  private readonly url: string = 'http://localhost:5035/api/Kluby';

  constructor(private httpClient: HttpClient) { }

  DajKluby(): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(this.url+ '/DajKluby');
  }

  DajArchiwalnegoPilkarza(IdKlubu: number, IdPilkarz: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(this.url+ '/DajArchiwalnegoPilkarza/' + IdKlubu + ',' + IdPilkarz);
  }

  DajArchiwalnychPilkarzy(IdKlubu: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(this.url + '/DajArchiwalnychPilkarzy/' + IdKlubu);
  }

  DajObecnegoPilkarza(IdKlubu: number, IdPilkarz: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(this.url+ '/DajObecnegoPilkarza/' + IdKlubu + ',' + IdPilkarz);
  }

  DajObecnychPilkarzy(IdKlubu: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(this.url + '/DajObecnychPilkarzy/' + IdKlubu);
  }

  DajTrofeaKlubu(IdKlubu: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(this.url + '/DajTrofeaKlubu/' + IdKlubu);
  }

  DajStadionKlubu(IdKlubu: number): Observable<PilkarzResponse[]> {
    return this.httpClient.get<PilkarzResponse[]>(this.url + '/DajStadionKlubu/' + IdKlubu);
  }

  DodajPilkarzaDoObecnych(IdPilkarza: number, IdKlubu: number): Observable<KlubResponse> {
    return this.httpClient.post<KlubResponse>(this.url + '/DodajPilkarzaDoObecnych/', IdPilkarza, IdKlubu);
  }

  UsunPilkarzaZObecnych(IdPilkarza: number, IdKlubu: number): Observable<KlubResponse> {
    return this.httpClient.post<KlubResponse>(this.url + '/UsunPilkarzaZObecnych/', IdPilkarza, IdKlubu);
  }
}
