import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Injectable } from '@angular/core';
import { Dependent } from '../models/dependent';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const employees: Employee[] = [
      { id: 1, employeeName: 'Shirley'},
      { id: 2, employeeName: 'Shdirley'},
      { id: 3, employeeName: 'Shidfvrley'},
      { id: 4, employeeName: 'Shirledfgdy'},
      { id: 5, employeeName: 'dfgShirley'},
      { id: 6, employeeName: 'Shfdgirley'},
      { id: 7, employeeName: 'Shirfdgley'},
      { id: 8, employeeName: 'Sfdghirley'},
      { id: 9, employeeName: 'Shirfdgley'},
      { id: 10, employeeName: 'Shifgrley'},
      { id: 11, employeeName: 'Shidfgdrley'},
      { id: 12, employeeName: 'Shirfgley'},
      { id: 13, employeeName: 'sadaShirley'},
      { id: 14, employeeName: 'weeqShirley'},
      { id: 15, employeeName: '34423Shirley'},
      { id: 16, employeeName: 'vdfv34Shirley'},
      { id: 17, employeeName: '34f324Shirley'},
      { id: 18, employeeName: 'ergerShirley'},
      { id: 19, employeeName: 'Shirlreey'},
      { id: 20, employeeName: 'Shirlerfey'},
      { id: 21, employeeName: 'Shifvfrley'},
      { id: 22, employeeName: 'Shivfdsfrley'},
      { id: 23, employeeName: 'Shirewrvsley'},
      { id: 24, employeeName: 'Shirrefewley'},
      { id: 25, employeeName: 'S4343hirley'},
      { id: 26, employeeName: '34t43Shirley'},
      { id: 27, employeeName: 'tShirley'},
      { id: 28, employeeName: 'vShirley'},
      { id: 29, employeeName: 'trgeShirley'},
      { id: 30, employeeName: '54gwShirley'},
      { id: 31, employeeName: 'reg4Shirley'},
      { id: 32, employeeName: '4t4weShirley'},
      { id: 33, employeeName: 'h56Shirley'},
      { id: 34, employeeName: '45grShirley'},
      { id: 35, employeeName: '4t5wShirley'},
      { id: 36, employeeName: 't4tShirley'},
      { id: 37, employeeName: 't2tShirley'},
      { id: 38, employeeName: 't234tShirley'},
      { id: 39, employeeName: 'yj6rytShirley'},
      { id: 40, employeeName: ',yu],Shirley'},
      { id: 41, employeeName: 'lk8978lShirley'},
      { id: 42, employeeName: '89l68itShirley'},
      { id: 43, employeeName: 'sdcaShirley'},
      { id: 44, employeeName: 'bgvcShirley'},
      { id: 45, employeeName: 'nhgfgShirley'},
      { id: 46, employeeName: 'i,iuyShirley'},
      { id: 47, employeeName: 'yuktShirley'},
      { id: 48, employeeName: 'Shirley'},
      { id: 49, employeeName: 'Shirley'},
      { id: 50, employeeName: 'Shirley'},
      { id: 51, employeeName: 'Shirley'},
      { id: 52, employeeName: 'Shirley'},
      { id: 53, employeeName: 'Shirley'},
      { id: 54, employeeName: 'Shirley'},
      { id: 55, employeeName: 'Shirley'},
      { id: 56, employeeName: 'Shirley'},
      { id: 57, employeeName: 'Shirley'},
    ];

    const dependents: Dependent[] = [
      { id: 1, name: 'burly1', employeeId: 1},
      { id: 2, name: 'burly2', employeeId: 1},
      { id: 3, name: 'burly3', employeeId: 1},
      { id: 4, name: 'burly4', employeeId: 1},
      { id: 5, name: 'burly5', employeeId: 1},
      { id: 6, name: 'burly6', employeeId: 1},
      { id: 7, name: 'burly7', employeeId: 1},
      { id: 8, name: 'burly8', employeeId: 1},
      { id: 9, name: 'burly9', employeeId: 1},
    ];
    return {employees, dependents};
  }
  

  // Overrides the genId method to ensure that a hero always has an id.
  // If the heroes array is empty,
  // the method below returns the initial number (11).
  // if the heroes array is not empty, the method below returns the highest
  // hero id + 1.
  genId<T extends Employee | Dependent>(myTable: T[]): number {
    return myTable.length > 0 ? Math.max(...myTable.map(t => t.id)) + 1 : 11;
  }
}