import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PracownikService } from 'src/app/Services/pracownik.service';
import { ZarzadService } from 'src/app/Services/zarzad.service';
import { Zarzad } from 'src/app/Zarzad/Models/zarzad.model';

@Component({
  selector: 'app-add-pracownik',
  templateUrl: './add-pracownik.component.html',
  styleUrls: ['./add-pracownik.component.css']
})
export class AddPracownikComponent {

  zarzad!: Zarzad;

  pracownik = new FormGroup({
    imie: new FormControl('', Validators.required),
    nazwisko: new FormControl('', Validators.required),
    pesel: new FormControl('', Validators.required),
    wiek: new FormControl('', Validators.required),
    wykonywanaFunkcja: new FormControl('', Validators.required),
    wynagrodzenie: new FormControl('', Validators.required),
    idZarzad: new FormControl('', Validators.required)
  });

  constructor(private pracownikService: PracownikService, private zarzadService: ZarzadService, private router: Router) {
    this.zarzadService.DajZarzady().subscribe(res => {
      this.zarzad = res[0]
      console.log(this.zarzad);
    })
  }

  DodajPracownika(): void {
    this.pracownik.value.idZarzad = this.zarzad.idZarzad;
    console.log(this.pracownik.value);
    this.pracownikService.DodajPracownika(this.pracownik.value).subscribe(res => {
      console.log("Dodano pracownika!");
      this.router.navigateByUrl("/Pracownicy");
    })
  }
}
