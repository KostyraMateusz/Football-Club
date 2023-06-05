import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PracownikResponse } from './Pracownik/Models/pracownik-response';
import { Observable } from 'rxjs';
import { ZarzadResponse } from './Zarzad/Models/zarzad-response';

@Injectable({
  providedIn: 'root'
})
export class PracownikService {

  private readonly url: string = 'http://localhost:5035/api/Pracownik';

  constructor(private httpClient: HttpClient) { }

  DajPracownikow(): Observable<PracownikResponse[]> {
    return this.httpClient.get<PracownikResponse[]>(this.url+ '/DajZarzady');
  }

  ZmienFunkcjePracownika(IdPracownik: number, funkcja: string): Observable<ZarzadResponse> {
    return this.httpClient.put<ZarzadResponse>(this.url + '/ZmienFunkcjePracownika/' + IdPracownik, funkcja);
  }
}
