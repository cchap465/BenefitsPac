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
      { id: 1, employeeName: 'Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 2, employeeName: 'Shdirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 3, employeeName: 'Shidfvrley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 4, employeeName: 'Shirledfgdy', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 5, employeeName: 'dfgShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 6, employeeName: 'Shfdgirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 7, employeeName: 'Shirfdgley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 8, employeeName: 'Sfdghirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 9, employeeName: 'Shirfdgley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 10, employeeName: 'Shifgrley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 11, employeeName: 'Shidfgdrley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 12, employeeName: 'Shirfgley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 13, employeeName: 'sadaShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 14, employeeName: 'weeqShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 15, employeeName: '34423Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 16, employeeName: 'vdfv34Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 17, employeeName: '34f324Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 18, employeeName: 'ergerShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 19, employeeName: 'Shirlreey', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 20, employeeName: 'Shirlerfey', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 21, employeeName: 'Shifvfrley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 22, employeeName: 'Shivfdsfrley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 23, employeeName: 'Shirewrvsley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 24, employeeName: 'Shirrefewley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 25, employeeName: 'S4343hirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 26, employeeName: '34t43Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 27, employeeName: 'tShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 28, employeeName: 'vShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 29, employeeName: 'trgeShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 30, employeeName: '54gwShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 31, employeeName: 'reg4Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 32, employeeName: '4t4weShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 33, employeeName: 'h56Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 34, employeeName: '45grShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 35, employeeName: '4t5wShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 36, employeeName: 't4tShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 37, employeeName: 't2tShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 38, employeeName: 't234tShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 39, employeeName: 'yj6rytShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 40, employeeName: ',yu],Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 41, employeeName: 'lk8978lShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 42, employeeName: '89l68itShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 43, employeeName: 'sdcaShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 44, employeeName: 'bgvcShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 45, employeeName: 'nhgfgShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 46, employeeName: 'i,iuyShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 47, employeeName: 'yuktShirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 48, employeeName: 'Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 49, employeeName: 'Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 50, employeeName: 'Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 51, employeeName: 'Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 52, employeeName: 'Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 53, employeeName: 'Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 54, employeeName: 'Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 55, employeeName: 'Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 56, employeeName: 'Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
      { id: 57, employeeName: 'Shirley', dependents: [ new Dependent(1, "bob", 1),  new Dependent(2, "fob", 1)]},
    ];
    return {employees};
  }

  // Overrides the genId method to ensure that a hero always has an id.
  // If the heroes array is empty,
  // the method below returns the initial number (11).
  // if the heroes array is not empty, the method below returns the highest
  // hero id + 1.
  genId(employees: Employee[]): number {
    return employees.length > 0 ? Math.max(...employees.map(employee => employee.id)) + 1 : 11;
  }
}