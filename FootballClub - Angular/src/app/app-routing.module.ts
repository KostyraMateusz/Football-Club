import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KlubDetailsComponent } from './Klub/components/klub-details/klub-details.component';
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
import { OthersKlubListComponent } from './Klub/components/others-klub-list/others-klub-list.component';
import { AddArchivalPlayerComponent } from './Klub/components/add-archival-player/add-archival-player.component';
import { AddCurrentPlayerComponent } from './Klub/components/add-current-player/add-current-player.component';
import { ChangePositionComponent } from './Pilkarz/components/change-position/change-position.component';
import { BestStatisticsComponent } from './Pilkarz/components/best-statistics/best-statistics.component';
import { PilkarzStatisticsComponent } from './Pilkarz/components/pilkarz-statistics/pilkarz-statistics.component';
import { OtherPilkarzListComponent } from './Pilkarz/components/other-pilkarz-list/other-pilkarz-list.component';

const routes: Routes = [
  { path: "", component: KlubDetailsComponent },
  { path: "Klub/RealMadryt/Szczegoly", component: KlubDetailsComponent },
  { path: "Kluby/DodajKlub", component: AddKlubComponent },
  { path: "Kluby/EdytujKlub/:id", component: EditKlubComponent },
  { path: "Kluby/InneKluby", component: OthersKlubListComponent },
  { path: "Kluby/DodajPilkarzaDoArchiwalnych", component: AddArchivalPlayerComponent },
  { path: "Kluby/DodajPilkarzaDoObecnych", component: AddCurrentPlayerComponent },
  { path: "Pilkarze", component: PilkarzListComponent },
  { path: "InniPilkarze", component: OtherPilkarzListComponent },
  { path: "Pilkarze/DodajPilkarza", component: AddPilkarzComponent },
  { path: "Pilkarze/EdytujPilkarza/:id", component: EditPilkarzComponent },
  { path: "Pilkarze/ZmienPozycjePilkarza", component: ChangePositionComponent },
  { path: "Pilkarze/NajlepszeStatystykiPilkarza", component: BestStatisticsComponent },
  { path: "Pilkarze/StatystykiPilkarza", component: PilkarzStatisticsComponent },
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
