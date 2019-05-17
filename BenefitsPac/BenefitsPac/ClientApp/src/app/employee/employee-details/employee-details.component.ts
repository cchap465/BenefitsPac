import { EmployeeService } from './../../shared/services/employee.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Employee } from 'src/app/shared/models/employee';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { EmployeeFormComponent } from 'src/app/employee-form/employee-form.component';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {
  employee: Employee;

  constructor(private route: ActivatedRoute,
    private employeeService: EmployeeService,
    private location: Location) { }

  ngOnInit() {
    this.getEmployee();
  }

  getEmployee(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.employeeService.getEmployee(id)
      .subscribe(employee => {
        this.employee = employee;
        /* this.employeeForm.get('hasDependents').valueChanges.subscribe(
          value => this.addDependentValidation(value)
        ); */
      });
  }

  save(): void {
    this.employeeService.updateEmployee(this.employee)
      .subscribe(() => this.goBack());
  }

  goBack(): void {
    this.location.back();
  }


  /* addDependentValidation(hasDependents: boolean): void {
    const hasDependentsControl = this.employeeForm.get('hasDe');
    if(hasDependents) {
      hasDependentsControl.setValidators(Validators.required);
    } else {
      hasDependentsControl.clearValidators();
    }

    hasDependentsControl.updateValueAndValidity();
  } */

}
