import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Pilkarz } from 'src/app/Pilkarz/Models/pilkarz.model';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { StatystykaService } from 'src/app/Services/statystyka.service';
import { Statystyka } from '../../Models/statystyka.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-statystyka',
  templateUrl: './add-statystyka.component.html',
  styleUrls: ['./add-statystyka.component.css']
})
export class AddStatystykaComponent implements OnInit {

  pilkarze: Pilkarz[] = [];
  statystyka!: FormGroup;
  nowaStatystyka!: Statystyka;

  constructor(private statystykaService: StatystykaService, private pilkarzService: PilkarzService,
    private formBuilder: FormBuilder, private router: Router) {
    this.getPilkarze();
  }

  ngOnInit(): void {
    this.getPilkarze();
    this.statystyka = this.formBuilder.group({
      Mecz: this.formBuilder.control(this.nowaStatystyka?.mecz, Validators.required),
      Gole: this.formBuilder.control(this.nowaStatystyka?.gole, Validators.required),
      Asysty: this.formBuilder.control(this.nowaStatystyka?.asysty, Validators.required),
      ZolteKartki: this.formBuilder.control(this.nowaStatystyka?.zolteKartki, Validators.required),
      CzerwoneKartki: this.formBuilder.control(this.nowaStatystyka?.czerwoneKartki, Validators.required),
      PrzebiegnietyDystans: this.formBuilder.control(this.nowaStatystyka?.przebiegnietyDystans, Validators.required),
      Ocena: this.formBuilder.control(this.nowaStatystyka?.ocena, Validators.required),
      IdPilkarz: this.formBuilder.control(this.nowaStatystyka?.idPilkarz, Validators.required)
    });
  }

  getPilkarze(): void {
    this.pilkarzService.DajPilkarzy().subscribe(res => {
      this.pilkarze = res;
      console.log(this.pilkarze);
    })
  }

  DodajStatystyke(): void {

    let id = this.statystyka.value.IdPilkarz[0];
    console.log(id);
    this.statystyka.value.IdPilkarz = id;
    console.log(this.statystyka.value);
    this.statystykaService.DodajStatystyke(this.statystyka.value).subscribe(res => {
      console.log("Dodano nową statystykę!");
      this.router.navigateByUrl("/Statystyki");
    })
  }
}
