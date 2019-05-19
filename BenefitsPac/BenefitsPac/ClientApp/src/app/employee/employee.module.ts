import { BenefitsBreakdownComponent } from './../benefits-breakdown/benefits-breakdown.component';
import { DependentsComponent } from './../dependents/dependents.component';
import { AppModule } from './../app.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmployeeComponent } from './employee.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { HttpClientModule } from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { MatTableModule, MatPaginatorModule, MatCardModule } from '@angular/material';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    RouterModule,
    MatTableModule,
    MatPaginatorModule,
    MatCardModule
  ],
  declarations: [
    EmployeeComponent,
    EmployeeDetailsComponent,
    DependentsComponent,
    BenefitsBreakdownComponent
  ],
  providers: [Location]
})
export class EmployeeModule { }
