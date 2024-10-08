import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExpenseType } from '../../Models/expenseType.model';

@Injectable({
  providedIn: 'root',
})
export class ExpenseTypeService {
  private apiUrl = 'https://localhost:7239/api/expenseType'; // Replace with your actual API endpoint

  constructor(private http: HttpClient) {}

  getExpenseTypes(): Observable<ExpenseType[]> {
    return this.http.get<ExpenseType[]>(this.apiUrl);
  }

  createExpenseType(expenseType: ExpenseType): Observable<ExpenseType> {
    return this.http.post<ExpenseType>(this.apiUrl, expenseType);
  }

  updateExpenseType(id: number, expenseType: ExpenseType): Observable<ExpenseType> {
    return this.http.put<ExpenseType>(`${this.apiUrl}/${id}`, expenseType);
  }

  deleteExpenseType(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
