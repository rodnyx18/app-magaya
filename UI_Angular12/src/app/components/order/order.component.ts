import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Order } from 'src/app/models/order.model';
import { ProductOrder } from 'src/app/models/product-order.model';
import { OrderService } from 'src/app/services/order.service';
import { ProductService } from 'src/app/services/product.service';
import { Product } from '../../models/product.model';
import { CustomersDetailsComponent } from '../customer/customer-details/customer-details.component';
import { PaymentTypesComponent } from '../payment/payment-type.component';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  @ViewChild(CustomersDetailsComponent ) customerDetail: CustomersDetailsComponent;
  @ViewChild(PaymentTypesComponent ) paymentType: PaymentTypesComponent; 

  order: Order = {};
  products: Product[] = [];
  productsOrder: ProductOrder[] = [];
  searchProductText: string = '';

  constructor(
    private productService: ProductService,
    private orderService: OrderService
    ) { }

  ngOnInit(): void {
    this.orderInit();
  }

  orderInit(): void {
    this.searchProductText = '';
    this.products = [];
    this.order = this.getEmptyOrder();
  }

  getEmptyOrder(): Order {
    const emptyOrder: Order = {
      id: 0,
      number: "",
      date: new Date(), 
      totalValue: 0,
      customerId: 0,
      paymentId: 0,
      productOrders: []
    };
    return emptyOrder;
  }

  searchProducts(): void {
    if (!this.searchProductText) {
      return;
    }
    this.productService.searchProducts(this.searchProductText)
      .subscribe(
        data => {
          this.products = data;
        },
        error => {
          console.log("error on productService.searchProducts()");
          console.log(error);
        });
  }

  createOrder(): void {
    const data: Order = this.getEmptyOrder();
    data.paymentId = this.paymentType.selectedType.id;
    data.customerId = this.customerDetail.customer.id;

    this.order.productOrders.forEach(p => data.productOrders.push(
      { 
        productId: p.productId, 
        quantity: p.quantity 
      }))
  
    this.orderService.create(data)
      .subscribe(
        response => {
          this.orderInit();
          this.customerDetail.loadCustomerDetail();
          console.log("orderService.create response");
          console.log(response);
        },
        error => {
          console.log("error on orderService.create");
          console.log(error);
        });
  }

  addProductOrder(product: Product): void {
    const i: number = this.order.productOrders.findIndex(p => p.productId == product.id);
    if (i == -1) {
      const newProductOrder: ProductOrder = {        
        productId: product.id,
        quantity: 1,
        description: product.description,
        price: product.price
      }
      this.order.productOrders.push(newProductOrder);
    }
    this.calculateOrderTotal();
  }

  addQuantity(productOrder: ProductOrder): void {
    productOrder.quantity++;
    this.calculateOrderTotal();
  }

  removeQuantity(productOrder: ProductOrder): void {
    if (productOrder.quantity > 1) {
      productOrder.quantity--;
      this.calculateOrderTotal();
    }      
  }

  hasProductOrder(): boolean {
    return this.order.productOrders.length > 0;
  }

  calculateOrderTotal(): void {
    let total: number = 0;    
    this.order.productOrders.forEach(p => total += p.price * p.quantity);
    this.order.totalValue = total;
  }

}
