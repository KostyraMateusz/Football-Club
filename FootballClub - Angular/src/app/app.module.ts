import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatDividerModule } from '@angular/material/divider';


import { KlubDetailsComponent } from './Klub/components/klub-details/klub-details.component';
import { AddKlubComponent } from './Klub/components/add-klub/add-klub.component';
import { EditKlubComponent } from './Klub/components/edit-klub/edit-klub.component';
import { MenuComponent } from './Menu/menu/menu.component';
import { AddPilkarzComponent } from './Pilkarz/components/add-pilkarz/add-pilkarz.component';
import { EditPilkarzComponent } from './Pilkarz/components/edit-pilkarz/edit-pilkarz.component';
import { PilkarzListComponent } from './Pilkarz/components/pilkarz-list/pilkarz-list.component';
import { AddPracownikComponent } from './Pracownik/components/add-pracownik/add-pracownik.component';
import { EditPracownikComponent } from './Pracownik/components/edit-pracownik/edit-pracownik.component';
import { PracownikListComponent } from './Pracownik/components/pracownik-list/pracownik-list.component';
import { StatystykaListComponent } from './Statystyka/components/statystyka-list/statystyka-list.component';
import { EditStatystykaComponent } from './Statystyka/components/edit-statystyka/edit-statystyka.component';
import { AddStatystykaComponent } from './Statystyka/components/add-statystyka/add-statystyka.component';
import { ChangeFunctionComponent } from './Pracownik/components/change-function/change-function.component';
import { ChangeSalaryComponent } from './Pracownik/components/change-salary/change-salary.component';
import { ChangeAgeComponent } from './Pracownik/components/change-age/change-age.component';
import { OthersKlubListComponent } from './Klub/components/others-klub-list/others-klub-list.component';
import { AddArchivalPlayerComponent } from './Klub/components/add-archival-player/add-archival-player.component';
import { AddCurrentPlayerComponent } from './Klub/components/add-current-player/add-current-player.component';
import { ChangePositionComponent } from './Pilkarz/components/change-position/change-position.component';
import { BestStatisticsComponent } from './Pilkarz/components/best-statistics/best-statistics.component';
import { PilkarzStatisticsComponent } from './Pilkarz/components/pilkarz-statistics/pilkarz-statistics.component';

@NgModule({
  declarations: [
    AppComponent,
    KlubDetailsComponent,
    AddKlubComponent,
    EditKlubComponent,
    MenuComponent,
    AddPilkarzComponent,
    EditPilkarzComponent,
    PilkarzListComponent,
    AddPracownikComponent,
    EditPracownikComponent,
    PracownikListComponent,
    StatystykaListComponent,
    EditStatystykaComponent,
    AddStatystykaComponent,
    ChangeFunctionComponent,
    ChangeSalaryComponent,
    ChangeAgeComponent,
    OthersKlubListComponent,
    AddArchivalPlayerComponent,
    AddCurrentPlayerComponent,
    ChangePositionComponent,
    BestStatisticsComponent,
    PilkarzStatisticsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatIconModule,
    MatPaginatorModule,
    MatSortModule,
    MatListModule,
    MatCardModule,
    MatProgressBarModule,
    MatDividerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
