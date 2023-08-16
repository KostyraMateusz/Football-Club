import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { StatystykaService } from 'src/app/Services/statystyka.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Statystyka } from '../../Models/statystyka.model';
import { Pilkarz } from 'src/app/Pilkarz/Models/pilkarz.model';

@Component({
  selector: 'app-edit-statystyka',
  templateUrl: './edit-statystyka.component.html',
  styleUrls: ['./edit-statystyka.component.css']
})
export class EditStatystykaComponent implements OnInit {

  pilkarze: Pilkarz[] = [];
  statystyka!: FormGroup;
  znalezionaStatystyka!: Statystyka;
  id: string = "";

  constructor(private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder,
    private statystykaService: StatystykaService, private router: Router, private cdref: ChangeDetectorRef) {
    this.getStatystyka();
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(res => {
      this.id = res['id'];

    })

    this.statystyka = this.formBuilder.group({
      Mecz: this.formBuilder.control(this.znalezionaStatystyka?.mecz, Validators.required),
      Gole: this.formBuilder.control(this.znalezionaStatystyka?.gole, Validators.required),
      Asysty: this.formBuilder.control(this.znalezionaStatystyka?.asysty, Validators.required),
      ZolteKartki: this.formBuilder.control(this.znalezionaStatystyka?.zolteKartki, Validators.required),
      CzerwoneKartki: this.formBuilder.control(this.znalezionaStatystyka?.czerwoneKartki, Validators.required),
      PrzebiegnietyDystans: this.formBuilder.control(this.znalezionaStatystyka?.przebiegnietyDystans, Validators.required),
      Ocena: this.formBuilder.control(this.znalezionaStatystyka?.ocena, Validators.required),
      IdPilkarz: this.formBuilder.control(this.znalezionaStatystyka?.idPilkarz, Validators.required)
    });

  }

  getStatystyka(): void {
    this.statystykaService.DajStatystyke(this.id).subscribe(res => {
      //this.statystyka.patchValue(res);
      this.znalezionaStatystyka = res;
      this.statystyka.value.IdStatystyka = this.znalezionaStatystyka.idStatystyka;
      this.statystyka.value.Mecz = this.znalezionaStatystyka.mecz;
      this.statystyka.value.Gole = this.znalezionaStatystyka.gole;
      this.statystyka.value.Asysty = this.znalezionaStatystyka.asysty;
      this.statystyka.value.ZolteKartki = this.znalezionaStatystyka.zolteKartki;
      this.statystyka.value.CzerwoneKartki = this.znalezionaStatystyka.czerwoneKartki;
      this.statystyka.value.PrzebiegnietyDystans = this.znalezionaStatystyka.przebiegnietyDystans;
      this.statystyka.value.Ocena = this.znalezionaStatystyka.ocena;
      this.statystyka.value.IdPilkarz = this.znalezionaStatystyka.idPilkarz;
      console.log(this.znalezionaStatystyka);
    })
    this.cdref.detectChanges();
  }

  EdytujStatystyke(): void {
    console.log(this.statystyka.value);
    this.statystykaService.EdytujStatystyke(this.id, this.statystyka.value).subscribe(res => {
      console.log("Klub został edytowany");
      this.router.navigateByUrl("/Statystyki");
    })
  }

}
