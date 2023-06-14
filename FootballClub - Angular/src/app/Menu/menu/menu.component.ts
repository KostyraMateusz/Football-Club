import { Component, OnChanges, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  myDate = new Date();
  title: string = "FootballClub";

  ngOnInit(): void {
  }
}
