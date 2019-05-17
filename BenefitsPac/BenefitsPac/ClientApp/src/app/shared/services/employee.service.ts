import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Employee } from '../models/employee';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private employeeUrl = 'api/employees';


  constructor(
    private http: HttpClient) { }

    getEmployees(): Observable<Employee[]> {
      return this.http.get<Employee[]>(this.employeeUrl)
      .pipe(
        tap(_ => console.log('fetched employees')),
        catchError(this.handleError<Employee[]>('getEmployees', []))
      );
    }

/** GET hero by id. Will 404 if id not found */
getEmployee(id: number): Observable<Employee> {
  const url = `${this.employeeUrl}/${id}`;
  return this.http.get<Employee>(url).pipe(
    tap(_ => console.log(`fetched hero id=${id}`)),
    catchError(this.handleError<Employee>(`getHero id=${id}`))
  );
}

/** PUT: update the hero on the server */
updateEmployee (employee: Employee): Observable<any> {
  return this.http.put(this.employeeUrl, employee, httpOptions).pipe(
    tap(_ => console.log(`updated hero id=${employee.id}`)),
    catchError(this.handleError<any>('updateHero'))
  );
}

      /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
private handleError<T> (operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {

    // TODO: send the error to remote logging infrastructure
    console.error(error); // log to console instead

    // TODO: better job of transforming error for user consumption
    console.log(`${operation} failed: ${error.message}`);

    // Let the app keep running by returning an empty result.
    return of(result as T);
  };
}
}
