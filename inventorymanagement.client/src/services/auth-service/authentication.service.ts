import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7239/api/user'; // Adjust to your API base URL

  constructor(private http: HttpClient) { }

  register(user: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  login(credentials: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, credentials);
  }
  getUserFirstName(): string {
    const firstName = localStorage.getItem('userName'); // Retrieve from local storage
    return firstName ? firstName : ''; // Return empty string if not found
  }
  storeUserData(token: string, firstName: string): void {
    localStorage.setItem('jwtToken', token); // Store the JWT token
    localStorage.setItem('userName', firstName); // Store the user's first name
  }

  logout(): Observable<any> {
    return this.http.post(`${this.apiUrl}/logout`, {}).pipe(
      tap(() => {
        // Remove tokens and user info from local storage on successful logout
        localStorage.removeItem('jwtToken');
      })
    );
  }
  isAuthenticated(): boolean {
    const token = localStorage.getItem('jwtToken'); 
    return !!token;
  }
}
