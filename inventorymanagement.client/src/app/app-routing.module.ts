import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from '../components/products/products.component';
import { ChartsComponent } from '../components/charts/charts.component';
import { InvestorComponent } from '../components/investor/investor.component';
import { InvestmentComponent } from '../components/investment/investment.component';
import { ProjectComponent } from '../components/project/project.component';
import { ExpenseTypeComponent } from '../components/expense-type/expense-type.component';
import { ExpenseComponent } from '../components/expense/expense.component';
import { AuthenticationComponent } from 'src/components/authentication/authentication.component';

const routes: Routes = [
  { path: '', redirectTo: '/auth', pathMatch: 'full' }, // Correct default redirect
  { path: 'auth', component: AuthenticationComponent },
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
