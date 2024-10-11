import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Expense } from '../../Models/expense.model';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root',
})
export class ExpenseService extends BaseService {
  private apiUrl = 'https://localhost:7239/api/expense';

  getExpenses(): Observable<Expense[]> {
    return this.get<Expense[]>(this.apiUrl);
  }

  createExpense(expense: Expense): Observable<Expense> {
    return this.post<Expense>(this.apiUrl, expense);
  }

  updateExpense(id: number, expense: Expense): Observable<Expense> {
    return this.put<Expense>(`${this.apiUrl}/${id}`, expense);
  }
  deleteExpense(id: number): Observable<void> {
    return this.delete(`${this.apiUrl}/${id}`);
  }
}
