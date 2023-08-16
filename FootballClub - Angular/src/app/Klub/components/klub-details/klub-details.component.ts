import { Component, OnInit } from '@angular/core';
import { KlubService } from 'src/app/Services/klub.service';
import { Klub } from '../../Models/klub.model';

@Component({
  selector: 'app-klub-list',
  templateUrl: './klub-details.component.html',
  styleUrls: ['./klub-details.component.css']
})
export class KlubDetailsComponent implements OnInit {

  kluby: Klub[] = [];
  real?: Klub;

  constructor(private klubService: KlubService) {
    this.getKluby();
  }

  ngOnInit(): void {
    this.getKluby();
  }

  getKluby() {
    this.klubService.DajKluby().subscribe(res => {
      this.kluby = res;
      this.real = res.find(k => k.nazwa.includes('Real Madryt'));
      console.log(this.kluby);
    })
  }
}
