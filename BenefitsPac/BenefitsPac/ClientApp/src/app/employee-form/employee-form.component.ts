import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormArray, Validators } from '@angular/forms';
import { Dependent } from '../shared/models/dependent';
import { Employee } from '../shared/models/employee';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../shared/services/employee.service';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {
  employee: Employee;
  dependent: Dependent;
  dependentForm: FormGroup;
  showDependents: false;

  constructor(private route: ActivatedRoute,
    private employeeService: EmployeeService,
    private fb: FormBuilder) { }

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

      this.dependentForm = this.fb.group({
        employeeName: ['', Validators.required],
        includeDependents: false,
        dependents: this.fb.array([this.buildDependent()])
      });
  }

  addDependent() {
    const control = <FormArray>this.dependentForm.controls['dependents'];
    control.push(this.buildDependent());
  }

  removeDependent(i: number) {
    const control = <FormArray>this.dependentForm.controls['dependents'];
    control.removeAt(i);
  }

  private buildDependent(): FormGroup {
    return this.fb.group({
      id: 0,
      dependentName: ['', Validators.required],
    });
  }
}
