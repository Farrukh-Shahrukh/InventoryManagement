import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Investor } from '../../Models/investor.model'; // Create this model accordingly

@Injectable({
  providedIn: 'root',
})
export class InvestorService {
  private apiUrl = 'https://localhost:7239/api/investor'; // Adjust API URL

  constructor(private http: HttpClient) {}

  getInvestors(): Observable<Investor[]> {
    return this.http.get<Investor[]>(this.apiUrl);
  }

  getInvestorById(id: number): Observable<Investor> {
    return this.http.get<Investor>(`${this.apiUrl}/${id}`);
  }

  createInvestor(investor: Investor): Observable<Investor> {
    return this.http.post<Investor>(this.apiUrl, investor);
  }

  updateInvestor(id: number, investor: Investor): Observable<Investor> {
    return this.http.put<Investor>(`${this.apiUrl}/${id}`, investor);
  }

  deleteInvestor(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
