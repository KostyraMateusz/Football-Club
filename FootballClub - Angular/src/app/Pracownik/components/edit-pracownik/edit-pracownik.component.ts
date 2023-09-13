import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PracownikService } from 'src/app/Services/pracownik.service';
import { Pracownik } from '../../Models/pracownik.model';

@Component({
  selector: 'app-edit-pracownik',
  templateUrl: './edit-pracownik.component.html',
  styleUrls: ['./edit-pracownik.component.css']
})
export class EditPracownikComponent {

  id!: string;
  pracownik!: FormGroup;
  znalezionyPracownik?: Pracownik;

  constructor(private pracownikService: PracownikService, private activatedRoute: ActivatedRoute, private router: Router,
    private formBuilder: FormBuilder) {

    this.activatedRoute.params.subscribe(res => {
      this.id = res['id'];
    })

    if (this.id !== '') {
      this.pracownikService.DajPracownika(this.id).subscribe(res => {
        this.znalezionyPracownik = res;
        this.pracownik.patchValue(res);
      })
    }

    this.pracownik = this.formBuilder.group({
      imie: this.formBuilder.control(this.znalezionyPracownik?.imie, Validators.required),
      nazwisko: this.formBuilder.control(this.znalezionyPracownik?.nazwisko, Validators.required),
      pesel: this.formBuilder.control(this.znalezionyPracownik?.wynagrodzenie, Validators.required),
      wiek: this.formBuilder.control(this.znalezionyPracownik?.wiek, Validators.required),
      wykonywanaFunkcja: this.formBuilder.control(this.znalezionyPracownik?.wykonywanaFunkcja, Validators.required),
      wynagrodzenie: this.formBuilder.control(this.znalezionyPracownik?.wynagrodzenie, Validators.required),
      idZarzad: this.formBuilder.control(this.znalezionyPracownik?.idZarzadu, Validators.required)
    });



  }

  EdytujPracownika(): void {
    this.pracownikService.EdytujPracownika(this.id, this.pracownik.value).subscribe(res => {
      console.log("Pracownik został edytowany.");
      this.router.navigateByUrl("/Pracownicy");
    })
  }


}
