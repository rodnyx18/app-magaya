import { Customer } from "./customer.model";
import { PaymentType } from "./payment-type.model";
import { ProductOrder } from "./product-order.model";

export class Order {
  id?: number;
  number?: string;
  date?: Date;
  customerId?: number;
  paymentId?: number;
  totalValue?: number;
  customer?: Customer;
  payment?: PaymentType;
  productOrders?: ProductOrder[];
}
