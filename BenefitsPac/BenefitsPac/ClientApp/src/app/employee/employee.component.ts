import { EmployeeService } from './../shared/services/employee.service';
import { Dependent } from '../shared/models/dependent';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Employee } from '../shared/models/employee';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})

export class EmployeeComponent implements OnInit {
  employees: Employee[];
  filteredEmployees: Employee[];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<Employee>;
  columnsToDisplay = ['id', 'name', 'edit'];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.getEmployees();
  }

  getEmployees(): void {
    this.employeeService.getEmployees()
    .subscribe(employees => {
      this.employees = employees;
      this.dataSource = new MatTableDataSource(this.employees);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      console.log(employees);
    });
  }

  applyFilter(value: string) {
    this.dataSource.filter = value.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  focusInput(input) {
    input.clear();
  }
}
