import { Component, OnInit } from '@angular/core';
import { Pracownik } from '../../Models/pracownik.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PracownikService } from 'src/app/Services/pracownik.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-change-function',
  templateUrl: './change-function.component.html',
  styleUrls: ['./change-function.component.css']
})
export class ChangeFunctionComponent implements OnInit {

  pracownicy: Pracownik[] = [];
  pracownik !: FormGroup;

  constructor(private pracownikService: PracownikService, private router: Router) {
    this.getPracownicy();
    this.pracownik = new FormGroup({
      idPracownik: new FormControl<string>('', Validators.required),
      wykonywanaFunkcja: new FormControl<string>('', Validators.required),
    });
  }

  ngOnInit(): void {
    this.getPracownicy();
  }

  getPracownicy(): void {
    this.pracownikService.DajPracownikow().subscribe(res => {
      this.pracownicy = res;
    })
  }

  getBack(): void {
    this.router.navigateByUrl('/Pracownicy');
  }

  ZmienFunkcjePracownika(): void {


    this.pracownikService.ZmienFunkcjePracownika(this.pracownik.value.idPracownik, JSON.stringify(this.pracownik.value.wykonywanaFunkcja)).subscribe(res => {
      this.getBack();
      console.log("Zmieniono funkcję pracownika");
    })
  }
}
