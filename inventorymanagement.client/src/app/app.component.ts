import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/services/auth-service/authentication.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  userFirstName: string = '';

  constructor(private http: HttpClient,private router: Router,private authService: AuthService) {}

  ngOnInit() {
    this.userFirstName = this.authService.getUserFirstName();
  }
  isLoginPage(): boolean {
    return this.router.url === '/auth';  // Adjust the path if necessary
  }
  logout(): void {
    this.authService.logout().subscribe({
      next: (response) => {
        this.router.navigate(['/auth']);
      },
      error: (error) => {
        console.error('Logout failed:', error); // Handle any errors
      }
    });
  }
}
