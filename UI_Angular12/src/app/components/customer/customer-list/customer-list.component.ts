import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomersListComponent implements OnInit {

  customers?: Customer[];
  currentCustomer: Customer = {};
  currentIndex = -1;
  message = '';
  messageClass = 'error-message'

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.getCustomers();
  }

  getCustomers(): void {
    this.customerService.getAll()
      .subscribe(
        data => {
          this.customers = data;
        },
        error => {
          if (error.error.functional) {
            this.showErrorMessage(error.error.errorMessage);
          }
        });
  }

  refreshList(): void {
    this.getCustomers();
    this.currentCustomer = {};
    this.currentIndex = -1;
  }

  setActiveCustomer(customer: Customer, index: number): void {
    this.currentCustomer = customer;
    this.currentIndex = index;
  }

  deleteCustomer(customerId: number): void {
    this.message = '';
    this.customerService.delete(customerId)
      .subscribe(
        _ => {
          this.getCustomers();
          this.showInformationMessage('The customer has been successfully removed.');
          //this.currentCustomer = {};
        },
        error => {
          if (error.error.functional) {
            this.showErrorMessage(error.error.errorMessage);
          }
        });
  }

  showInformationMessage(message: string): void {
    this.message = message;
    this.messageClass = 'information-message';
  }

  showErrorMessage(message: string): void {
    this.message = message;
    this.messageClass = 'error-message';
  }
}
