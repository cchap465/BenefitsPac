import { Dependent } from './../../shared/models/dependent';
import { EmployeeService } from './../../shared/services/employee.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Employee } from 'src/app/shared/models/employee';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { DependentsService } from 'src/app/shared/services/dependents.service';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {
  employee = new Employee();
  dependent = new Dependent();
  dependents: Dependent[];
  filteredDependents: Dependent[];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<Dependent>;
  columnsToDisplay = ['id', 'name', 'delete'];

  constructor(private route: ActivatedRoute,
    private employeeService: EmployeeService,
    private dependentsService: DependentsService,
    private location: Location) { }

  ngOnInit() {
    this.getEmployee();
    this.getDependents();
  }

  getEmployee(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.employeeService.getEmployee(id)
      .subscribe(employee => {
        this.employee = employee;
    });
  }

  getDependents():void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.dependentsService.getDependentsByEmployeeId(id)
      .subscribe(dependents => {
        this.dependents = dependents;
        this.dataSource = new MatTableDataSource(this.dependents);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    });
  }

  saveEmployee(name: string): void {
    this.employee.employeeName = name;
    this.employeeService.updateEmployee(this.employee)
      .subscribe();
  }

  addDependent(name: string): void {
    this.dependent.name = name;
    this.dependentsService.addDependent(name, this.employee.id)
      .subscribe(dependent => {
        this.dependents.push({ id: dependent.id, name: name, employeeId: this.employee.id })
        this.setTableData();
      });
  }

  deleteDependent(id: number): void {
    this.dependentsService.deleteDependent(id)
      .subscribe(dependent => {
        this.dependents = this.dependents.filter( h => h.id !== id);
        this.setTableData();
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

  private setTableData() {
    this.dataSource = new MatTableDataSource(this.dependents);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}
