import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Klub } from '../Klub/Models/klub.model';
import { Pilkarz } from '../Pilkarz/Models/pilkarz.model';

@Injectable({
  providedIn: 'root'
})
export class KlubService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(private httpClient: HttpClient) { }

  DajKlub(id: string): Observable<Klub> {
    return this.httpClient.get<Klub>(environment.url + "Kluby/DajKlub/" + id);
  }

  DodajKlub(klub: any): Observable<void> {
    return this.httpClient.post<void>(environment.url + "Kluby/DodajKlub", klub);
  }

  EdytujKlub(id: string, klub: any): Observable<void> {
    return this.httpClient.put<void>(environment.url + "Kluby/EdytujKlub/" + id, klub);
  }

  DeleteKlub(id: string): Observable<void> {
    return this.httpClient.delete<void>(environment.url + "Kluby/UsuńKlub/" + id);
  }

  DajKluby(): Observable<Klub[]> {
    return this.httpClient.get<Klub[]>(environment.url + 'Kluby/DajKluby');
  }

  DajArchiwalnegoPilkarza(IdKlubu: string, IdPilkarz: string): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajArchiwalnegoPilkarza/' + IdKlubu + ',' + IdPilkarz);
  }

  DajArchiwalnychPilkarzy(IdKlubu: string): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajArchiwalnychPilkarzy/' + IdKlubu);
  }

  DajObecnegoPilkarza(IdKlubu: string, IdPilkarz: string): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajObecnegoPilkarza/' + IdKlubu + ',' + IdPilkarz);
  }

  DajObecnychPilkarzy(IdKlubu: number): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajObecnychPilkarzy/' + IdKlubu);
  }

  DajTrofeaKlubu(IdKlubu: number): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajTrofeaKlubu/' + IdKlubu);
  }

  DajStadionKlubu(IdKlubu: number): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajStadionKlubu/' + IdKlubu);
  }

  DodajPilkarzaDoObecnych(IdKlubu: string, pilkarz: Pilkarz): Observable<void> {
    return this.httpClient.post<void>(environment.url + 'Kluby/' + IdKlubu + '/DodajPilkarzaDoObecnych', pilkarz);
  }

  UsunPilkarzaZObecnych(IdPilkarza: string, IdKlubu: string): Observable<void> {
    return this.httpClient.delete<void>(environment.url + 'Kluby/UsunPilkarzaZObecnych/' + IdPilkarza + ',' + IdKlubu);
  }

  DodajPilkarzaDoArchiwalnych(Pilkarz: Pilkarz, IdKlubu: string): Observable<void> {
    return this.httpClient.post<void>(environment.url + 'Kluby/' + IdKlubu + '/DodajPilkarzaDoArchiwalnych/', Pilkarz);
  }
}
