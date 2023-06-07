import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ZarzadResponse } from './Zarzad/Models/zarzad-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ZarzadService {

  private readonly url: string = 'http://localhost:5035/api/Zarzady';

  constructor(private httpClient: HttpClient) { }

  DajZarzady(): Observable<ZarzadResponse[]> {
    return this.httpClient.get<ZarzadResponse[]>(this.url+ '/DajZarzady');
  }

  DajWynikFinansowy(IdZarzadu: number): Observable<ZarzadResponse[]> {
    return this.httpClient.get<ZarzadResponse[]>(this.url+ '/DajWynikFinansowy/' + IdZarzadu);
  }
}
