import { BenefitsBreakdownComponent } from './benefits-breakdown/benefits-breakdown.component';
import { EmployeeComponent } from './employee/employee.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeDetailsComponent } from './employee/employee-details/employee-details.component';

const routes: Routes = [
  { path: 'employees', component: EmployeeComponent },
  { path: 'employeeDetail/:id', component: EmployeeDetailsComponent},
  { path: 'benefitsBreakdown/:id', component: BenefitsBreakdownComponent},
  { path: '', redirectTo: '/employees', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
