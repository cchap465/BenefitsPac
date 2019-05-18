import { EmployeeFormModule } from './../employee-form/employee-form.module';
import { AppModule } from './../app.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchModule } from './../search/search.module';
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
    SearchModule,
    BrowserAnimationsModule,
    FormsModule,
    RouterModule,
    EmployeeFormModule,
    MatTableModule,
    MatPaginatorModule,
    MatCardModule
  ],
  declarations: [
    EmployeeComponent,
    EmployeeDetailsComponent,
  ],
  providers: [Location]
})
export class EmployeeModule { }
