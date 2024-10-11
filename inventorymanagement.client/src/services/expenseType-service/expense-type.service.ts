import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ExpenseType } from '../../Models/expenseType.model';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root',
})
export class ExpenseTypeService extends BaseService {
  private apiUrl = 'https://localhost:7239/api/expenseType'; // Replace with your actual API endpoint

  getExpenseTypes(): Observable<ExpenseType[]> {
    return this.get<ExpenseType[]>(this.apiUrl);
  }

  createExpenseType(expenseType: ExpenseType): Observable<ExpenseType> {
    return this.post<ExpenseType>(this.apiUrl, expenseType);
  }

  updateExpenseType(id: number, expenseType: ExpenseType): Observable<ExpenseType> {
    return this.put<ExpenseType>(`${this.apiUrl}/${id}`, expenseType);
  }

  deleteExpenseType(id: number): Observable<void> {
    return this.delete(`${this.apiUrl}/${id}`);
  }
}
