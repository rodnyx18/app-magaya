import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersListComponent } from './components/customer/customer-list/customer-list.component';
import { CustomersDetailsComponent } from './components/customer/customer-details/customer-details.component';
import { CustomersAddComponent } from './components/customer/customer-add/customer-add.component';
import { OrderComponent } from './components/order/order.component';
import { PaymentTypesComponent } from './components/payment/payment-type.component';
import { OrdersListComponent } from './components/order/order-list/order-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'customers', pathMatch: 'full' },
  { path: 'customers/:id', component: CustomersDetailsComponent },
  { path: 'add/customers', component: CustomersAddComponent },
  { path: 'customers', component: CustomersListComponent },
  { path: 'order/:id', component: OrderComponent },
  { path: 'payment', component: PaymentTypesComponent },
  { path: 'orders', component: OrdersListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
