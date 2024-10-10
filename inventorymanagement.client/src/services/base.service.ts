import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class BaseService {
  constructor(private http: HttpClient) {}

  protected getAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem('jwtToken');
    return new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    });
  }

  protected get<T>(url: string): Observable<T> {
    return this.http.get<T>(url, { headers: this.getAuthHeaders() });
  }

  protected post<T>(url: string, body: any): Observable<T> {
    return this.http.post<T>(url, body, { headers: this.getAuthHeaders() });
  }

  protected put<T>(url: string, body: any): Observable<T> {
    return this.http.put<T>(url, body, { headers: this.getAuthHeaders() });
  }

  protected delete(url: string): Observable<void> {
    return this.http.delete<void>(url, { headers: this.getAuthHeaders() });
  }
}
