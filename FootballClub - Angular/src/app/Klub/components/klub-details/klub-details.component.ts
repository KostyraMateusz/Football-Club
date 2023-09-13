import { Component, OnInit } from '@angular/core';
import { KlubService } from 'src/app/Services/klub.service';
import { Klub } from '../../Models/klub.model';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { Pilkarz } from 'src/app/Pilkarz/Models/pilkarz.model';

@Component({
  selector: 'app-klub-list',
  templateUrl: './klub-details.component.html',
  styleUrls: ['./klub-details.component.css']
})
export class KlubDetailsComponent implements OnInit {

  kluby: Klub[] = [];
  real?: Klub;
  obecniPilkarze: Pilkarz[] = [];

  constructor(private klubService: KlubService, private pilkarzService: PilkarzService) {
    this.getKluby();
    this.getPilkarzeReal()
  }

  ngOnInit(): void {
    this.getKluby();
    this.getPilkarzeReal()
  }

  getKluby() {
    this.klubService.DajKluby().subscribe(res => {
      this.kluby = res;
      this.real = res.find(k => k.nazwa.includes('Real Madryt'));
      console.log(this.kluby);
    })
  }


  getPilkarzeReal(): void {
    this.pilkarzService.DajPilkarzy().subscribe(res => {
      console.log(this.obecniPilkarze);
      this.obecniPilkarze = res.filter(p => p.klub?.nazwa == 'Real Madryt');
    })
  }
}
