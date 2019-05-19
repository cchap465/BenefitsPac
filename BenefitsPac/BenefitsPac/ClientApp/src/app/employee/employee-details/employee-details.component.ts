import { EmployeeService } from './../../shared/services/employee.service';
import { Component, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { Employee } from 'src/app/shared/models/employee';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {
  employee = new Employee();
  header = 'Add New Employee';
  @Output() someEvent = new EventEmitter<any>();

  constructor(private route: ActivatedRoute,
    private employeeService: EmployeeService,
    private location: Location) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    if (id > 0) {
      this.getEmployee();
    } 
  }

  getEmployee(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.employeeService.getEmployee(id)
      .subscribe(employee => {
        this.employee = employee;
        this.header = 'Employee Management';
    });
  }

  saveEmployee(name: string) {
    this.employee.employeeName = name;
    if(this.employee.employeeId > 0) {
      this.employeeService.updateEmployee(this.employee)
      .subscribe();
    } else {
      this.employeeService.createEmployee(this.employee)
      .subscribe();
    }
    this.someEvent.(event);
  }
}
