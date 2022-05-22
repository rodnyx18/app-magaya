import { Address } from "./address.model";
import { Order } from "./order.model";

export class Customer {
  id?: number;
  name?: string;
  phone?: string;
  email?: string;
  addressId?: number;
  address?: Address;
  orders?: Order[];
}
