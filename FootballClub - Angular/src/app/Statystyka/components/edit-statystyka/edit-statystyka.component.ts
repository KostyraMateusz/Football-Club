import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { StatystykaService } from 'src/app/Services/statystyka.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Statystyka } from '../../Models/statystyka.model';
import { Pilkarz } from 'src/app/Pilkarz/Models/pilkarz.model';
import { PilkarzService } from 'src/app/Services/pilkarz.service';

@Component({
  selector: 'app-edit-statystyka',
  templateUrl: './edit-statystyka.component.html',
  styleUrls: ['./edit-statystyka.component.css']
})
export class EditStatystykaComponent {

  pilkarze: Pilkarz[] = [];
  statystyka!: FormGroup;
  znalezionaStatystyka!: Statystyka;
  pilkarz?: Pilkarz;
  id: string = "";

  constructor(private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder,
    private statystykaService: StatystykaService, private router: Router, private pilkarzService: PilkarzService) {
    this.activatedRoute.params.subscribe(res => {
      this.id = res['id'];
    })

    this.statystyka = this.formBuilder.group({
      mecz: this.formBuilder.control(this.znalezionaStatystyka?.mecz, Validators.required),
      gole: this.formBuilder.control(this.znalezionaStatystyka?.gole, Validators.required),
      asysty: this.formBuilder.control(this.znalezionaStatystyka?.asysty, Validators.required),
      zolteKartki: this.formBuilder.control(this.znalezionaStatystyka?.zolteKartki, Validators.required),
      czerwoneKartki: this.formBuilder.control(this.znalezionaStatystyka?.czerwoneKartki, Validators.required),
      przebiegnietyDystans: this.formBuilder.control(this.znalezionaStatystyka?.przebiegnietyDystans, Validators.required),
      ocena: this.formBuilder.control(this.znalezionaStatystyka?.ocena, Validators.required),
      idPilkarz: this.formBuilder.control(this.znalezionaStatystyka?.idPilkarz, Validators.required)
    });
    if (this.id !== '') {
      this.statystykaService.DajStatystyke(this.id).subscribe(res => {
        this.statystyka.patchValue(res);
      });
    }

    this.DajPilkarza();
  }


  EdytujStatystyke(): void {
    console.log(this.statystyka.value);
    this.statystykaService.EdytujStatystyke(this.id, this.statystyka.value).subscribe(res => {
      console.log("Klub został edytowany");
      this.router.navigateByUrl("/Statystyki");
    })
  }

  DajPilkarza(): void {
    this.pilkarzService.DajPilkarzy().subscribe(res => {
      console.log(this.id);
      this.pilkarz = res.find(p => p.idPilkarz === this.statystyka.value.idPilkarz);
      console.log(this.pilkarz);
    })
  }

}
