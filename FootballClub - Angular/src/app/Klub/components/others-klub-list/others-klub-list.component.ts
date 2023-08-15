import { Component, OnInit } from '@angular/core';
import { KlubService } from 'src/app/Services/klub.service';
import { Klub } from '../../Models/klub.model';

@Component({
  selector: 'app-others-klub-list',
  templateUrl: './others-klub-list.component.html',
  styleUrls: ['./others-klub-list.component.css']
})
export class OthersKlubListComponent implements OnInit {

  otherClubs: Klub[] = [];
  displayedColumns: string[] = ['Nazwa', 'Stadion', 'Trofea', 'Archiwalni Piłkarze', 'Obecni Piłkarze', 'Edytuj', 'Usuń'];
  constructor(private klubService: KlubService) {
    this.getOtherClubs();
  }

  ngOnInit(): void {
    this.getOtherClubs();
  }

  getOtherClubs(): void {
    this.klubService.DajKluby().subscribe(res => {
      this.otherClubs = res.filter(k => !k.nazwa.includes('Real Madryt'));
      console.log(this.otherClubs);
    })
  }


}
