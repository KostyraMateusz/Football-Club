import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KlubListComponent } from './Klub/components/klub-list/klub-list.component';
import { AddKlubComponent } from './Klub/components/add-klub/add-klub.component';
import { EditKlubComponent } from './Klub/components/edit-klub/edit-klub.component';
import { PilkarzListComponent } from './Pilkarz/components/pilkarz-list/pilkarz-list.component';
import { AddPilkarzComponent } from './Pilkarz/components/add-pilkarz/add-pilkarz.component';
import { EditPilkarzComponent } from './Pilkarz/components/edit-pilkarz/edit-pilkarz.component';
import { PracownikListComponent } from './Pracownik/components/pracownik-list/pracownik-list.component';
import { AddPracownikComponent } from './Pracownik/components/add-pracownik/add-pracownik.component';
import { EditPracownikComponent } from './Pracownik/components/edit-pracownik/edit-pracownik.component';
import { StatystykaListComponent } from './Statystyka/components/statystyka-list/statystyka-list.component';
import { AddStatystykaComponent } from './Statystyka/components/add-statystyka/add-statystyka.component';
import { EditStatystykaComponent } from './Statystyka/components/edit-statystyka/edit-statystyka.component';
import { ChangeSalaryComponent } from './Pracownik/components/change-salary/change-salary.component';
import { ChangeFunctionComponent } from './Pracownik/components/change-function/change-function.component';
import { ChangeAgeComponent } from './Pracownik/components/change-age/change-age.component';

const routes: Routes = [
  { path: "", component: KlubListComponent },
  { path: "Kluby", component: KlubListComponent },
  { path: "Kluby/DodajKlub", component: AddKlubComponent },
  { path: "Kluby/EdytujKlub/:id", component: EditKlubComponent },
  { path: "Pilkarze", component: PilkarzListComponent },
  { path: "Pilkarze/DodajPilkarza", component: AddPilkarzComponent },
  { path: "Pilkarze/EdytujPilkarza/:id", component: EditPilkarzComponent },
  { path: "Pracownicy", component: PracownikListComponent },
  { path: "Pracownicy/DodajPracownika", component: AddPracownikComponent },
  { path: "Pracownicy/EdytujPracownika/:id", component: EditPracownikComponent },
  { path: "Pracownicy/ZmienPensjePracownika", component: ChangeSalaryComponent },
  { path: "Pracownicy/ZmienFunkcjePracownika", component: ChangeFunctionComponent },
  { path: "Pracownicy/ZmienWiekPracownika", component: ChangeAgeComponent },
  { path: "Statystyki", component: StatystykaListComponent },
  { path: "Statystyki/DodajStatystyke", component: AddStatystykaComponent },
  { path: "Statystyki/EdytujStatystyke/:id", component: EditStatystykaComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
