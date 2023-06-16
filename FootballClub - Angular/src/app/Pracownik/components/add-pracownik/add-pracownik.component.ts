import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PracownikService } from 'src/app/Services/pracownik.service';

@Component({
  selector: 'app-add-pracownik',
  templateUrl: './add-pracownik.component.html',
  styleUrls: ['./add-pracownik.component.css']
})
export class AddPracownikComponent {

  pracownik = new FormGroup({
    Imie: new FormControl('', Validators.required),
    Nazwisko: new FormControl('', Validators.required),
    PESEL: new FormControl('', Validators.required),
    Wiek: new FormControl('', Validators.required),
    WykonywanaFunkcja: new FormControl('', Validators.required),
    Wynagrodzenie: new FormControl('', Validators.required),
  });

  constructor(private pracownikService: PracownikService) {}

  DodajPracownika(): void {
    console.log(this.pracownik);
  }
}
