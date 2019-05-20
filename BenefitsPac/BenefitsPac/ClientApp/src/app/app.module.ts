import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { MatTableModule, MatPaginatorModule, MatCardModule } from '@angular/material';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { DependentsComponent } from './dependents/dependents.component';
import { BenefitsBreakdownComponent } from './benefits-breakdown/benefits-breakdown.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    EmployeeDetailsComponent,
    DependentsComponent,
    BenefitsBreakdownComponent,
    EmployeeListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    RouterModule,
    MatTableModule,
    MatPaginatorModule,
    MatCardModule
  ],
  providers: [Location],
  bootstrap: [AppComponent]
})
export class AppModule { }
