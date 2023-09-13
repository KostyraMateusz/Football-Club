import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Pilkarz } from 'src/app/Pilkarz/Models/pilkarz.model';
import { KlubService } from 'src/app/Services/klub.service';
import { PilkarzService } from 'src/app/Services/pilkarz.service';
import { ZarzadService } from 'src/app/Services/zarzad.service';
import { Zarzad } from 'src/app/Zarzad/Models/zarzad.model';

@Component({
  selector: 'app-add-klub',
  templateUrl: './add-klub.component.html',
  styleUrls: ['./add-klub.component.css']
})
export class AddKlubComponent implements OnInit {

  pilkarze: Pilkarz[] = [];
  klub!: FormGroup;

  constructor(private klubService: KlubService, private pilkarzService: PilkarzService, private zarzadService: ZarzadService,
    private formBuilder: FormBuilder, private router: Router) {
    this.getPilkarze();
  }

  ngOnInit(): void {
    this.getPilkarze();
    this.klub = new FormGroup({
      nazwa: new FormControl('', Validators.required),
      stadion: new FormControl('', Validators.required),
      trofea: new FormControl('', Validators.required),
    });
  }


  getPilkarze(): void {
    this.pilkarzService.DajPilkarzy().subscribe(res => {
      this.pilkarze = res;
      console.log(this.pilkarze);
    })
  }

  DodajKlub(): void {
    console.log(this.klub.value);
    this.klubService.DodajKlub(this.klub.value).subscribe(res => {
      console.log("Klub został dodany");
      this.router.navigateByUrl("/Kluby/InneKluby");
    })
  }

  getBack(): void{
    this.router.navigateByUrl("/Kluby/InneKluby");
  }
}
