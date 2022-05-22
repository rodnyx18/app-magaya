import { Component, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customers-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css']
})
export class CustomersDetailsComponent implements OnInit {

  @Output() customer: Customer = {};
  customerId: number;
  title = '';
  message = '';
  ordersNumber = 0;

  constructor(
    private customerService: CustomerService,
    private route: ActivatedRoute) 
    { }

  ngOnInit(): void {
    this.message = '';
    this.customerId = this.route.snapshot.params.id;
    this.loadCustomerDetail();
  }

  public loadCustomerDetail() {
    this.getCustomer(this.customerId);
  }

  getCustomer(id: number): void {
    this.customerService.get(id)
      .subscribe(
        data => {
          this.customer = data;
          this.ordersNumber = this.customer.orders.length;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }
}
