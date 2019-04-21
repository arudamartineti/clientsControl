import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IPaymentControl } from '../interfaces/payment-control';

@Injectable({
  providedIn: 'root'
})
export class PaymentControlService {

  private apiUrl = this.baseUrl + "api/paymentControls";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getPaymentControls(): Observable<IPaymentControl[]> {
    return this.http.get<IPaymentControl[]>(this.apiUrl);
  }

  createPaymentControl(paymentControl: IPaymentControl): Observable<IPaymentControl> {
    return this.http.post<IPaymentControl>(this.apiUrl, paymentControl);
  }
}
