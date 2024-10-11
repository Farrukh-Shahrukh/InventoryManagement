import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Investment } from '../../Models/investment.model';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root',
})
export class InvestmentService extends BaseService {
  private apiUrl = 'https://localhost:7239/api/investments';

  getInvestments(): Observable<Investment[]> {
    return this.get<Investment[]>(this.apiUrl);
  }

  getInvestmentById(id: number): Observable<Investment> {
    return this.get<Investment>(`${this.apiUrl}/${id}`);
  }

  createInvestment(investment: Investment): Observable<Investment> {
    return this.post<Investment>(this.apiUrl, investment);
  }

  updateInvestment(id: number, investment: Investment): Observable<Investment> {
    return this.put<Investment>(`${this.apiUrl}/${id}`, investment);
  }

  deleteInvestment(id: number): Observable<void> {
    return this.delete(`${this.apiUrl}/${id}`);
  }
}
