import { Component } from '@angular/core';
import { AuthService } from '../../services/auth-service/authentication.service';
import { Router } from '@angular/router';
import { RegisterUserModel } from '../../Models/user.model';
import { LoginModel } from '../../Models/user.model';

@Component({
  selector: 'app-auth',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.css']
})
export class AuthenticationComponent {
  // Models for registration and login
  public user: RegisterUserModel = {
    firstName: '',
    lastName: '',
    email: '',
    password: ''
  };

  public credentials: LoginModel = {
    email: '',
    password: ''
  };

  public confirmPassword: string = ''; // To hold confirm password
  public isLoginMode: boolean = true; // Toggle between login and signup
  public message: string = ''; // To show error or success messages
  passwordsMatch: boolean = true;

  constructor(private authService: AuthService, private router: Router) {}

  toggleMode() {
    this.isLoginMode = !this.isLoginMode;
    this.message = '';
    this.confirmPassword = ''; 
  }

  get email() {
    return this.isLoginMode ? this.credentials.email : this.user.email;
  }

  set email(value: string) {
    if (this.isLoginMode) {
      this.credentials.email = value;
    } else {
      this.user.email = value;
    }
  }

  get password() {
    return this.isLoginMode ? this.credentials.password : this.user.password;
  }

  set password(value: string) {
    if (this.isLoginMode) {
      this.credentials.password = value;
    } else {
      this.user.password = value;
    }
  }

  checkPasswordsMatch() {
    this.passwordsMatch = this.password === this.confirmPassword;
  }
  // Common method to handle login or signup based on mode
  authenticate() {
    if (!this.passwordsMatch && !this.isLoginMode) {
      this.message = 'Passwords do not match';
      return;
    }

    if (this.isLoginMode) {
      this.login();
    } else {
      this.signup();
    }
  }

  // Login user
  login() {
    this.authService.login(this.credentials).subscribe(
      (response: any) => {
        this.authService.storeUserData(response.token, response.userName);
        this.router.navigate(['/investors']); // Navigate to dashboard after login
      },
      (error) => {
        this.message = 'Invalid credentials';
        console.error(error);
      }
    );
  }

  // Register new user
  signup() {
    this.authService.register(this.user).subscribe(
      (response) => {
        this.message = 'User registered successfully!';
        this.toggleMode(); // After signup, switch to login mode
      },
      (error) => {
        if (error.error && error.error.errors && error.error.errors.Password) {
          this.message = error.error.errors.Password.join(', ')
        } else {
          this.message = 'Error registering user. Please try again.';
        }
        console.error(error);
      }
    );
  }
  

}