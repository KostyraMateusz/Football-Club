import { Component, OnInit } from '@angular/core';
import { Pracownik } from '../../Models/pracownik.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PracownikService } from 'src/app/Services/pracownik.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-change-age',
  templateUrl: './change-age.component.html',
  styleUrls: ['./change-age.component.css']
})
export class ChangeAgeComponent implements OnInit {

  pracownicy: Pracownik[] = [];
  pracownik !: FormGroup;

  constructor(private pracownikService: PracownikService, private router: Router) {
    this.getPracownicy();
    this.pracownik = new FormGroup({
      idPracownik: new FormControl('', Validators.required),
      wiek: new FormControl('', Validators.required),
    });
  }
  ngOnInit(): void {
    this.getPracownicy();
  }

  ZmienWiekPracownika(): void {
    console.log(this.pracownik.value);
    this.pracownikService.ZmienWiekPracownika(this.pracownik.value.idPracownik, this.pracownik.value.wiek).subscribe(res => {
      this.getBack();
    })
  }

  getBack(): void {
    this.router.navigateByUrl('/Pracownicy');
  }

  getPracownicy(): void {
    this.pracownikService.DajPracownikow().subscribe(res => {
      this.pracownicy = res
      console.log(this.pracownicy);
    })
  }

}
