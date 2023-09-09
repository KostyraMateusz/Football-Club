import { Component, OnInit } from '@angular/core';
import { KlubService } from 'src/app/Services/klub.service';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { ZarzadService } from 'src/app/Services/zarzad.service';
import { Klub } from '../../Models/klub.model';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Zarzad } from 'src/app/Zarzad/Models/zarzad.model';
import { Pilkarz } from 'src/app/Pilkarz/Models/pilkarz.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-klub',
  templateUrl: './edit-klub.component.html',
  styleUrls: ['./edit-klub.component.css']
})
export class EditKlubComponent {

  zarzady!: Zarzad[];
  pilkarze!: Pilkarz[];
  foundKlub!: Klub;
  klub!: FormGroup;
  id: string = "";

  constructor(private klubService: KlubService, private pilkarzService: PilkarzService, private zarzadService: ZarzadService, private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder, private router: Router) {
    activatedRoute.params.subscribe(res => {
      this.id = res['id'];
    })


    if (this.id !== '') {
      this.klubService.DajKlub(this.id).subscribe(res => {
        this.foundKlub = res;
        this.klub.patchValue(res);
      })
    }

    this.klub = this.formBuilder.group({
      idKlub: this.formBuilder.control(this.foundKlub?.idKlub, Validators.required),
      nazwa: this.formBuilder.control(this.foundKlub?.nazwa, Validators.required),
      stadion: this.formBuilder.control(this.foundKlub?.stadion, Validators.required),
      trofea: this.formBuilder.control(this.foundKlub?.trofea, Validators.required),
    });
  }

  EdytujKlub(): void {
    this.klubService.EdytujKlub(this.id, this.klub.value).subscribe(res => {
      console.log("Klub został edytowany");
      this.router.navigateByUrl("/Kluby/InneKluby")
    })
  }
}
