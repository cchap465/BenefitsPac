import { EmployeeService } from './../shared/services/employee.service';
import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { Employee } from '../shared/models/employee';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  filterButtonText = 'Filter Employees';
  show = false;
  employees: Employee[];
  filteredEmployees: Employee[];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<Employee>;
  columnsToDisplay = ['id', 'name', 'edit', 'delete', 'benefitsBreakdown'];

  constructor(private employeeService: EmployeeService,
    private cd: ChangeDetectorRef) { }

  ngOnInit() {
    this.getEmployees();
  }

  getEmployees(): void {
    this.employeeService.getEmployees()
      .subscribe(employees => {
        this.employees = employees;
        this.setDataSource();
        this.cd.markForCheck();
      });
  }

  deleteEmployee(id: number): void {
    this.employeeService.deleteEmployee(id)
      .subscribe(() => {
        this.employees = this.employees.filter(h => h.employeeId !== id);
        this.setDataSource();
      });
  }

  applyFilter(value: string) {
    this.dataSource.filter = value.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  toggle() {
    this.show = !this.show;
    if (this.show) {
      this.filterButtonText = 'Remove Filter';
    } else {
      this.filterButtonText = 'Filter Employees';
    }
    this.setDataSource();
  }

  private setDataSource() {
    this.dataSource = new MatTableDataSource(this.employees);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}
