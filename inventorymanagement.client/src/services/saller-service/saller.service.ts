import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Saller } from '../../Models/saller.model';

@Injectable({
  providedIn: 'root'
})
export class SallerServiceService {
  private apiUrl = 'https://localhost:7239/api/saller';

  constructor(private http: HttpClient) {}

  getSallers(): Observable<Saller[]> {
    return this.http.get<Saller[]>(this.apiUrl);
  }

  createSaller(formData: FormData): Observable<Saller> {
    return this.http.post<Saller>(this.apiUrl, formData);
  }

  updateSaller(id: number, formData: FormData): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, formData);
  }
}
