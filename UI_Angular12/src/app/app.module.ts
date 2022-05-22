import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomersListComponent } from './components/customer/customer-list/customer-list.component';
import { CustomersDetailsComponent } from './components/customer/customer-details/customer-details.component';
import { CustomersAddComponent } from './components/customer/customer-add/customer-add.component';
import { FormsModule } from '@angular/forms';
import { OrderComponent } from './components/order/order.component';
import { PaymentTypesComponent } from './components/payment/payment-type.component';
import { OrdersListComponent } from './components/order/order-list/order-list.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomersListComponent,
    CustomersDetailsComponent,
    CustomersAddComponent,
    OrderComponent,
    OrdersListComponent,
    PaymentTypesComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
