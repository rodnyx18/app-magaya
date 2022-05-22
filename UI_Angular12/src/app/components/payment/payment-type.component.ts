import { Component, OnInit, Output } from '@angular/core';
import { PaymentType } from 'src/app/models/payment-type.model';
import { PaymentTypeService } from 'src/app/services/payment-type.service';

@Component({
  selector: 'app-payment-type',
  templateUrl: './payment-type.component.html',
  styleUrls: ['./payment-type.component.css']
})
export class PaymentTypesComponent implements OnInit {  

  @Output() selectedType: PaymentType;
  paymentTypes: PaymentType[];

  constructor(private paymentTypeService: PaymentTypeService) 
  { }

  ngOnInit(): void {
    this.getPaymentTypes();
  }

  getPaymentTypes(): void {
    this.paymentTypeService.getAll()
      .subscribe(
        data => {
          this.paymentTypes = data;
          if (this.paymentTypes.length > 0) {
            this.selectedType = data[0];
          }         
          console.log("response on paymentTypeService.getAll()");
          console.log(data);
        },
        error => {
          console.log("error on paymentTypeService.getAll()");
          console.log(error);
        });
  }
}
