import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DependentsService } from '../shared/services/dependents.service';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Dependent } from '../shared/models/dependent';

@Component({
  selector: 'app-dependents',
  templateUrl: './dependents.component.html',
  styleUrls: ['./dependents.component.css']
})
export class DependentsComponent implements OnInit {
  employeeId = +this.route.snapshot.paramMap.get('id');
  dependent = new Dependent();
  dependents: Dependent[];
  filteredDependents: Dependent[];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<Dependent>;
  columnsToDisplay = ['id', 'name', 'delete'];

  constructor(private route: ActivatedRoute,
    private dependentsService: DependentsService) { }

  ngOnInit() {
    this.getDependents();
  }

  getDependents(): void {
    this.dependentsService.getDependentsByEmployeeId(this.employeeId)
      .subscribe(dependents => {
        this.dependents = dependents;
        this.dependent.employeeId = this.employeeId;
        this.setTableData();
      });
  }

  addDependent(): void {
    this.dependentsService.addDependent(this.dependent)
      .subscribe(dependentId => {
        this.dependents.push({
          dependentId: dependentId,
          dependentName: this.dependent.dependentName,
          employeeId: this.employeeId
        });
        this.setTableData();
      });
  }

  deleteDependent(id: number): void {
    this.dependentsService.deleteDependent(id)
      .subscribe(() => {
        this.dependents = this.dependents.filter(h => h.dependentId !== id);
        this.setTableData();
      });
  }

  applyFilter(value: string) {
    this.dataSource.filter = value.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  private setTableData() {
    this.dataSource = new MatTableDataSource(this.dependents);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}
