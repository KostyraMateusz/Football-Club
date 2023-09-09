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
    return this.httpClient.get<Klub>(environment.url + "Kluby/DajKlub/" + id, this.httpOptions);
  }

  DodajKlub(klub: any): Observable<void> {
    return this.httpClient.post<void>(environment.url + "Kluby/DodajKlub", klub, this.httpOptions);
  }

  EdytujKlub(id: string, klub: any): Observable<void> {
    return this.httpClient.put<void>(environment.url + "Kluby/EdytujKlub/" + id, klub, this.httpOptions);
  }

  DeleteKlub(id: string): Observable<void> {
    return this.httpClient.delete<void>(environment.url + "Kluby/UsuńKlub/" + id, this.httpOptions);
  }

  DajKluby(): Observable<Klub[]> {
    return this.httpClient.get<Klub[]>(environment.url + 'Kluby/DajKluby', this.httpOptions);
  }

  DajArchiwalnegoPilkarza(idKlubu: string, IdPilkarz: string): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajArchiwalnegoPilkarza/' + idKlubu + ',' + IdPilkarz, this.httpOptions);
  }

  DajArchiwalnychPilkarzy(idKlubu: string): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajArchiwalnychPilkarzy/' + idKlubu, this.httpOptions);
  }

  DajObecnegoPilkarza(idKlubu: string, IdPilkarz: string): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajObecnegoPilkarza/' + idKlubu + ',' + IdPilkarz, this.httpOptions);
  }

  DajObecnychPilkarzy(idKlubu: number): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajObecnychPilkarzy/' + idKlubu, this.httpOptions);
  }

  DajTrofeaKlubu(idKlubu: number): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajTrofeaKlubu/' + idKlubu, this.httpOptions);
  }

  DajStadionKlubu(idKlubu: number): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajStadionKlubu/' + idKlubu, this.httpOptions);
  }

  DodajPilkarzaDoObecnych(idKlubu: string, pilkarz: Pilkarz): Observable<void> {
    return this.httpClient.post<void>(environment.url + 'Kluby/' + idKlubu + '/DodajPilkarzaDoObecnych', pilkarz, this.httpOptions);
  }

  UsunPilkarzaZObecnych(IdPilkarza: string, idKlubu: string): Observable<void> {
    return this.httpClient.delete<void>(environment.url + 'Kluby/UsunPilkarzaZObecnych/' + IdPilkarza + ',' + idKlubu);
  }

  DodajPilkarzaDoArchiwalnych(Pilkarz: Pilkarz, idKlubu: string): Observable<void> {
    return this.httpClient.post<void>(environment.url + 'Kluby/' + idKlubu + '/DodajPilkarzaDoArchiwalnych/', Pilkarz);
  }
}
