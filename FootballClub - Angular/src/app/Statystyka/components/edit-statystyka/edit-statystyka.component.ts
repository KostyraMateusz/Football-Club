import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { StatystykaResponse } from '../../Models/statystyka-response';
import { StatystykaService } from 'src/app/Services/statystyka.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-statystyka',
  templateUrl: './edit-statystyka.component.html',
  styleUrls: ['./edit-statystyka.component.css']
})
export class EditStatystykaComponent {

  form!: FormGroup;
  statystyka?: StatystykaResponse;



}
