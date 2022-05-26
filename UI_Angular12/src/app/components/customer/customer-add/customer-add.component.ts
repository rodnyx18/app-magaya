import { Component, OnInit } from '@angular/core';
import { Address } from 'src/app/models/address.model';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-add',
  templateUrl: './customer-add.component.html',
  styleUrls: ['./customer-add.component.css']
})
export class CustomersAddComponent implements OnInit {

  customer: {};
  submitted = false;
  message: string;

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.newCustomer();
  }

  saveCustomer(): void {
    this.customerService.create(this.customer)
      .subscribe(
        _ => {
          this.submitted = true;
          this.message = '';
        },
        error => {
          if (error.error.functional) {
            this.message = error.error.errorMessage;
          }
        });
  }

  newCustomer(): void {
    this.submitted = false;
    this.customer = {
      id: 0,
      name: '',
      phone: '',
      email: '',
      addressId: 0,
      address: { id: 0, number: '', street: '', city: '', zipCode: '', state:'', country:'' }
    };
  }

}
