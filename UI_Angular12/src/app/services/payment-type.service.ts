import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaymentType } from '../models/payment-type.model';

const baseUrl = 'https://localhost:7236/api/paymenttype';

@Injectable({
  providedIn: 'root'
})
export class PaymentTypeService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<PaymentType[]> {
    return this.http.get<PaymentType[]>(baseUrl);
  }

}
