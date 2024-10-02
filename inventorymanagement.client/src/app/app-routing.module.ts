import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { ChartsComponent } from './charts/charts.component';
import { InvestorComponent } from './investor/investor.component';
import { InvestmentComponent } from './investment/investment.component';

const routes: Routes = [
  { path: 'investors', component: InvestorComponent },
  { path: 'investments', component: InvestmentComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'charts', component: ChartsComponent },
  { path: '', redirectTo: '/investors', pathMatch: 'full' }, // Correct default redirect
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
