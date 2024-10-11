import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { InvestorComponent } from '../components/investor/investor.component';
import { InvestmentComponent } from '../components/investment/investment.component';
import { ProjectComponent } from '../components/project/project.component';
import { ExpenseComponent } from '../components/expense/expense.component';
import { ExpenseTypeComponent } from '../components/expense-type/expense-type.component';
import { AuthenticationComponent } from '../components/authentication/authentication.component';

@NgModule({
  declarations: [
    AppComponent,
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
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
