import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PracownikResponse } from '../Pracownik/Models/pracownik-response';
import { Observable } from 'rxjs';
import { ZarzadResponse } from '../Zarzad/Models/zarzad-response';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PracownikService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(private httpClient: HttpClient) { }

  DajPracownikow(): Observable<PracownikResponse[]> {
    return this.httpClient.get<PracownikResponse[]>(environment.url + '/DajZarzady');
  }

  ZmienFunkcjePracownika(IdPracownik: number, funkcja: string): Observable<ZarzadResponse> {
    return this.httpClient.put<ZarzadResponse>(environment.url + '/ZmienFunkcjePracownika/' + IdPracownik, funkcja);
  }
}
