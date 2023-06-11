import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ZarzadResponse } from '../Zarzad/Models/zarzad-response';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ZarzadService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(private httpClient: HttpClient) { }

  DajZarzady(): Observable<ZarzadResponse[]> {
    return this.httpClient.get<ZarzadResponse[]>(environment.url + '/DajZarzady');
  }

  DajWynikFinansowy(IdZarzadu: number): Observable<ZarzadResponse[]> {
    return this.httpClient.get<ZarzadResponse[]>(environment.url + '/DajWynikFinansowy/' + IdZarzadu);
  }
}
