import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Dependent } from '../models/dependent';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class DependentsService {
  private dependentUrl = 'api/dependents';


  constructor(
    private http: HttpClient) { }

    getDependents(): Observable<Dependent[]> {
      return this.http.get<Dependent[]>(this.dependentUrl)
      .pipe(
        tap(_ => console.log('fetched dependents')),
        catchError(this.handleError<Dependent[]>('getDependents', []))
      );
    }

/** GET hero by id. Will 404 if id not found */
getDependent(id: number): Observable<Dependent> {
  const url = `${this.dependentUrl}/${id}`;
  return this.http.get<Dependent>(url).pipe(
    tap(_ => console.log(`fetched dependent id=${id}`)),
    catchError(this.handleError<Dependent>(`getDependent id=${id}`))
  );
}

/** PUT: update the hero on the server */
updateDependent (dependent: Dependent): Observable<any> {
  return this.http.put(this.dependentUrl, dependent, httpOptions).pipe(
    tap(_ => console.log(`updated dependent id=${dependent.id}`)),
    catchError(this.handleError<any>('updateDependent'))
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
