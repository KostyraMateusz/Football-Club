import { Component, OnInit } from '@angular/core';
import { KlubService } from 'src/app/Services/klub.service';
import { Klub } from '../../Models/klub.model';

@Component({
  selector: 'app-klub-list',
  templateUrl: './klub-list.component.html',
  styleUrls: ['./klub-list.component.css']
})
export class KlubListComponent implements OnInit {

  kluby: Klub[] = [];
  displayedColumns: string[] = ['Nazwa', 'Stadion', 'Trofea', 'Archiwalni Piłkarze', 'Obecni Piłkarze', 'Edytuj', 'Usuń'];

  constructor(private klubService: KlubService) {
    this.getKluby();
  }

  ngOnInit(): void {
    this.getKluby();
  }

  getKluby() {
    this.klubService.DajKluby().subscribe(res => {
      this.kluby = res;
      console.log(this.kluby);
    })
  }
}
