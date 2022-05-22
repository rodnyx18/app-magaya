import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/models/order.model';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrdersListComponent implements OnInit {

  orders?: Order[];
  currentOrder: Order = {};
  currentIndex = -1;

  constructor(private orderService: OrderService) { }

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders(): void {
    this.orderService.getAll()
      .subscribe(
        data => {
          this.orders = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  deleteOrder(orderId: number): void {
    this.orderService.delete(orderId)
      .subscribe(
        data => {
          console.log(data);
          this.getOrders();
        },
        error => {
          console.log(error);
        });
  }

  refreshList(): void {
    this.getOrders();
    this.currentOrder = {};
    this.currentIndex = -1;
  }

  setActiveOrder(order: Order, index: number): void {
    this.currentOrder = order;
    this.currentIndex = index;
  }
}
