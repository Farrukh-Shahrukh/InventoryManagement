import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Investment } from '../../Models/investment.model';

@Injectable({
  providedIn: 'root',
})
export class InvestmentService {
  private apiUrl = 'https://localhost:7239/api/investments';

  constructor(private http: HttpClient) {}

  getInvestments(): Observable<Investment[]> {
    return this.http.get<Investment[]>(this.apiUrl);
  }

  getInvestmentById(id: number): Observable<Investment> {
    return this.http.get<Investment>(`${this.apiUrl}/${id}`);
  }

  createInvestment(investment: Investment): Observable<Investment> {
    return this.http.post<Investment>(this.apiUrl, investment);
  }

  updateInvestment(id: number, investment: Investment): Observable<Investment> {
    return this.http.put<Investment>(`${this.apiUrl}/${id}`, investment);
  }

  deleteInvestment(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
