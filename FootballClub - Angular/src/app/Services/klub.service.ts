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

  DajArchiwalnegoPilkarza(IdKlubu: string, IdPilkarz: string): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajArchiwalnegoPilkarza/' + IdKlubu + ',' + IdPilkarz, this.httpOptions);
  }

  DajArchiwalnychPilkarzy(IdKlubu: string): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajArchiwalnychPilkarzy/' + IdKlubu, this.httpOptions);
  }

  DajObecnegoPilkarza(IdKlubu: string, IdPilkarz: string): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajObecnegoPilkarza/' + IdKlubu + ',' + IdPilkarz, this.httpOptions);
  }

  DajObecnychPilkarzy(IdKlubu: number): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajObecnychPilkarzy/' + IdKlubu, this.httpOptions);
  }

  DajTrofeaKlubu(IdKlubu: number): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajTrofeaKlubu/' + IdKlubu, this.httpOptions);
  }

  DajStadionKlubu(IdKlubu: number): Observable<Pilkarz[]> {
    return this.httpClient.get<Pilkarz[]>(environment.url + 'Kluby/DajStadionKlubu/' + IdKlubu, this.httpOptions);
  }

  DodajPilkarzaDoObecnych(IdKlubu: string, pilkarz: Pilkarz): Observable<void> {
    return this.httpClient.post<void>(environment.url + 'Kluby/' + IdKlubu + '/DodajPilkarzaDoObecnych', pilkarz, this.httpOptions);
  }

  UsunPilkarzaZObecnych(IdPilkarza: string, IdKlubu: string): Observable<void> {
    return this.httpClient.delete<void>(environment.url + 'Kluby/UsunPilkarzaZObecnych/' + IdPilkarza + ',' + IdKlubu);
  }

  DodajPilkarzaDoArchiwalnych(Pilkarz: Pilkarz, IdKlubu: string): Observable<void> {
    return this.httpClient.post<void>(environment.url + 'Kluby/' + IdKlubu + '/DodajPilkarzaDoArchiwalnych/', Pilkarz);
  }
}
