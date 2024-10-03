import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { ChartsComponent } from './charts/charts.component';
import { InvestorComponent } from './investor/investor.component';
import { InvestmentComponent } from './investment/investment.component';
import { ProjectComponent } from './project/project.component';
import { ExpenseTypeComponent } from './expense-type/expense-type.component';
import { ExpenseComponent } from './expense/expense.component';

const routes: Routes = [
  { path: '', redirectTo: '/investors', pathMatch: 'full' }, // Correct default redirect
  { path: 'investors', component: InvestorComponent },
  { path: 'investments', component: InvestmentComponent },
  { path: 'projects', component: ProjectComponent },
  { path: 'expenseTypes', component: ExpenseTypeComponent },
  { path: 'expenses', component: ExpenseComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'charts', component: ChartsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
