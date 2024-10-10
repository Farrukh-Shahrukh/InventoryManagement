import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Investor } from '../../Models/investor.model';
import { BaseService } from '../base.service'; // Import the base service

@Injectable({
  providedIn: 'root',
})
export class InvestorService extends BaseService {
  private apiUrl = 'https://localhost:7239/api/investor';

  getInvestors(): Observable<Investor[]> {
    return this.get<Investor[]>(this.apiUrl);
  }

  getInvestorById(id: number): Observable<Investor> {
    return this.get<Investor>(`${this.apiUrl}/${id}`);
  }

  createInvestor(investor: Investor): Observable<Investor> {
    return this.post<Investor>(this.apiUrl, investor);
  }

  updateInvestor(id: number, investor: Investor): Observable<Investor> {
    return this.put<Investor>(`${this.apiUrl}/${id}`, investor);
  }

  deleteInvestor(id: number): Observable<void> {
    return this.delete(`${this.apiUrl}/${id}`);
  }
}
