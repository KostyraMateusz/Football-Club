import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { StatystykaService } from 'src/app/Services/statystyka.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Statystyka } from '../../Models/statystyka.model';

@Component({
  selector: 'app-edit-statystyka',
  templateUrl: './edit-statystyka.component.html',
  styleUrls: ['./edit-statystyka.component.css']
})
export class EditStatystykaComponent {

  form!: FormGroup;
  statystyka?: Statystyka;



}
