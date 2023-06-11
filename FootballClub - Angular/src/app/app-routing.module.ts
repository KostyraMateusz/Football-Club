import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KlubListComponent } from './Klub/components/klub-list/klub-list.component';
import { AddKlubComponent } from './Klub/components/add-klub/add-klub.component';
import { EditKlubComponent } from './Klub/components/edit-klub/edit-klub.component';

const routes: Routes = [
  { path: "", component: KlubListComponent },
  { path: "Kluby", component: KlubListComponent },
  { path: "Kluby/DodajKlub", component: AddKlubComponent },
  { path: "Kluby/EdytujKlub", component: EditKlubComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
