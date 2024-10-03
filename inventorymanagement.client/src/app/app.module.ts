import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module'; // Import routing module
import { FormsModule } from '@angular/forms';
import { ChartsComponent } from './charts/charts.component';
import { InvestorComponent } from './investor/investor.component';
import { InvestmentComponent } from './investment/investment.component';
import { ProjectComponent } from './project/project.component';
import { ExpenseComponent } from './expense/expense.component';
import { ExpenseTypeComponent } from './expense-type/expense-type.component'; // Import FormsModule

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
    ExpenseTypeComponent
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
