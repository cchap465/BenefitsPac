import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BenefitsBreakdown } from '../models/benefits-breakdown';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BenefitsService {
  private benefitsUrl = '/api/Benefits';

  constructor(private http: HttpClient) { }

  getBenefitsBreakDown(employeeId: number): Observable<BenefitsBreakdown> {
    return this.http.get<BenefitsBreakdown>(`${this.benefitsUrl}/GetBenefitsCostBreakdownByEmployeeId/${employeeId}`)
      .pipe(catchError(this.handleError<BenefitsBreakdown>('getDependents')));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      console.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
}
