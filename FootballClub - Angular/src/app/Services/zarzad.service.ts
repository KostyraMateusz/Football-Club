import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Zarzad } from '../Zarzad/Models/zarzad.model';

@Injectable({
  providedIn: 'root'
})
export class ZarzadService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(private httpClient: HttpClient) { }

  DajZarzady(): Observable<Zarzad[]> {
    return this.httpClient.get<Zarzad[]>(environment.url + 'Zarzady/DajZarzady');
  }

  DajWynikFinansowy(IdZarzadu: number): Observable<Zarzad[]> {
    return this.httpClient.get<Zarzad[]>(environment.url + 'Zarzady/DajWynikFinansowy/' + IdZarzadu);
  }
}
