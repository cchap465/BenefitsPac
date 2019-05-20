import { Dependent } from './../models/dependent';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class DependentsService {
  private dependentUrl = '/api/Dependent';


  constructor(private http: HttpClient) { }

  getDependentsByEmployeeId(employeeId: number): Observable<Dependent[]> {
    return this.http.get<Dependent[]>(`${this.dependentUrl}/GetDependentsByEmployeeId/${employeeId}`)
      .pipe(
        catchError(this.handleError<Dependent[]>('getDependents', []))
      );
  }

  getDependent(id: number): Observable<Dependent> {
    const url = `${this.dependentUrl}/${id}`;
    return this.http.get<Dependent>(url).pipe(
      catchError(this.handleError<Dependent>(`getDependent id=${id}`))
    );
  }

  addDependent(dependent: Dependent): Observable<number> {
    return this.http.post(this.dependentUrl, dependent, httpOptions).pipe(
      catchError(this.handleError<any>('updateDependent'))
    );
  }

  updateDependent(dependent: Dependent): Observable<any> {
    return this.http.put(this.dependentUrl, dependent, httpOptions).pipe(
      catchError(this.handleError<any>('updateDependent'))
    );
  }

  deleteDependent(id: number): Observable<any> {
    const url = `${this.dependentUrl}/${id}`;
    return this.http.delete(url).pipe(
      catchError(this.handleError<any>('deleteDependent'))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      console.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
}
