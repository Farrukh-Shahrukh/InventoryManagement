import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvestorComponent } from '../components/investor/investor.component';
import { InvestmentComponent } from '../components/investment/investment.component';
import { ProjectComponent } from '../components/project/project.component';
import { ExpenseTypeComponent } from '../components/expense-type/expense-type.component';
import { ExpenseComponent } from '../components/expense/expense.component';
import { AuthenticationComponent } from 'src/components/authentication/authentication.component';
import { AuthGuard } from './auth-guard'; // Import the guard

const routes: Routes = [
  { path: '', redirectTo: '/investors', pathMatch: 'full' }, 
  { path: 'auth', component: AuthenticationComponent },
  { path: 'investors', component: InvestorComponent, canActivate: [AuthGuard] },
  { path: 'investments', component: InvestmentComponent, canActivate: [AuthGuard] },
  { path: 'projects', component: ProjectComponent, canActivate: [AuthGuard] },
  { path: 'expenseTypes', component: ExpenseTypeComponent, canActivate: [AuthGuard] },
  { path: 'expenses', component: ExpenseComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
