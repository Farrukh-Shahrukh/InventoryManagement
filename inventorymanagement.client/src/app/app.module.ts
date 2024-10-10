import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ProductsComponent } from '../components/products/products.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module'; // Import routing module
import { FormsModule } from '@angular/forms';
import { ChartsComponent } from '../components/charts/charts.component';
import { InvestorComponent } from '../components/investor/investor.component';
import { InvestmentComponent } from '../components/investment/investment.component';
import { ProjectComponent } from '../components/project/project.component';
import { ExpenseComponent } from '../components/expense/expense.component';
import { ExpenseTypeComponent } from '../components/expense-type/expense-type.component';
import { AuthenticationComponent } from '../components/authentication/authentication.component'; // Import FormsModule
import { AuthInterceptor } from './auth.interceptor';

// const routes: Routes = [
//   { path: 'investors', component: InvestorComponent },
//   { path: 'products', component: ProductsComponent },
//   { path: 'charts', component: ChartsComponent },
//   { path: '', redirectTo: '/investors', pathMatch: 'full' }, // Correct default redirect
// ];

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    ChartsComponent,
    InvestorComponent,
    InvestmentComponent,
    ProjectComponent,
    ExpenseComponent,
    ExpenseTypeComponent,
    AuthenticationComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    NgbModule,
    FormsModule
  ],
  exports: [RouterModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
