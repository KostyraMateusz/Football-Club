import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PracownikService } from 'src/app/Services/pracownik.service';
import { Pracownik } from '../../Models/pracownik.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-change-salary',
  templateUrl: './change-salary.component.html',
  styleUrls: ['./change-salary.component.css']
})
export class ChangeSalaryComponent implements OnInit {

  pracownicy: Pracownik[] = [];
  pracownik !: FormGroup;

  constructor(private pracownikService: PracownikService, private router: Router) {
    this.getPracownicy();
    this.pracownik = new FormGroup({
      idPracownik: new FormControl('', Validators.required),
      wynagrodzenie: new FormControl('', Validators.required),
    });
  }

  ngOnInit(): void {
    this.getPracownicy();
  }

  getPracownicy(): void {
    this.pracownikService.DajPracownikow().subscribe(res => {
      this.pracownicy = res
      console.log(this.pracownicy);
    })
  }

  getBack(): void {
    this.router.navigateByUrl('/Pracownicy');
  }

  ZmienWynagrodzenie(): void {
    this.pracownik.value.idPracownik = this.pracownik.value.idPracownik;
    console.log(this.pracownik.value);
    if (this.pracownik.value.idPracownik && this.pracownik.value.wynagrodzenie) {
      this.pracownikService.ZmienPensjePracownika(this.pracownik.value.idPracownik, this.pracownik.value.wynagrodzenie).subscribe(res => {
        this.getBack();
      })
    }


  }
}
