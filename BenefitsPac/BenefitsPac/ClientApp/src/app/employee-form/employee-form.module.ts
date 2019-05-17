import { EmployeeFormComponent } from './employee-form.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule, MatIconModule, MatFormFieldModule, MatCardModule, MatDividerModule, MatTableModule, MatPaginatorModule, MatInputModule, MatOptionModule, MatSelectModule } from '@angular/material';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    MatCheckboxModule,
    MatIconModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatCardModule,
    MatDividerModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatOptionModule,
    MatSelectModule,
  ],
  declarations: [
    EmployeeFormComponent
  ],
  exports: [
    EmployeeFormComponent
  ]
})
export class EmployeeFormModule { }
