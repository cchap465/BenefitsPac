import { BenefitsBreakdownComponent } from './benefits-breakdown/benefits-breakdown.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';

const routes: Routes = [
  { path: 'Home', component: EmployeeListComponent },
  { path: 'EmployeeDetail/:id', component: EmployeeDetailsComponent },
  { path: 'BenefitsBreakdown/:id', component: BenefitsBreakdownComponent },
  { path: '', redirectTo: '/Home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
