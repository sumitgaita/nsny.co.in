import { Injectable, EventEmitter } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CommissionPayService {
  static onEditpaymentUpdateRow = new EventEmitter<any>();
  static onEditpaymentUpdatestatusRow = new EventEmitter<any>();
  constructor(private http: HttpService) { }

  getAllAdminPayment(): Observable<any> {
    return this.http.get<any>('CommissionPay');
  }
  getAdminPaymentGeneratedatBranch(): Observable<any> {
    return this.http.get<any>('PaymentCollection');
  }
  createCommissionPay(courseObject: any): Observable<any> {
    return this.http.post<any>('CommissionPay', courseObject);
  }

  getPaymentGeneratedforHQ(branchId: number): Observable<any> {
    return this.http.get<any>('CommissionPay?branchId=' + branchId);
  }
  getStudentPaymentDetails(studentId: string): Observable<any> {
    return this.http.outSiteGet<any>('Upload?studentId=' + studentId);
  }
  getAdminPaymentSendHQ(): Observable<any> {
    return this.http.get<any>('PaymentCollection?admin=' + '');
  }
  paymentUpdate(paymentId: number): Observable<any> {
    return this.http.get<any>('PaymentCollection?paymentId=' + paymentId + '&isAdmin=' + false);
  }
  paymentUpdatestatus(paymentId: number): Observable<any> {
    return this.http.get<any>('PaymentCollection?paymentId=' + paymentId + '&admin=' + '');
  }
  getCompletedtoHQ(branchId: number): Observable<any> {
    return this.http.get<any>('CommissionPay?branchId=' + branchId + '&branchCode=' + '');
  }

  getPaymentRemaining(branchId: number): Observable<any> {
    return this.http.get<any>('CommissionPay?branchId=' + branchId + '&commision=' + 0);
  }

  getPaymentGeneratedatBranch(branchId: number): Observable<any> {
    return this.http.get<any>('PaymentCollection?branchId=' + branchId);
  }

  getPaymentSendtoHQ(branchId: number): Observable<any> {
    return this.http.get<any>('PaymentCollection?branchId=' + branchId + '&branchCode=' + 0);
  }

  updateCourseBindPayment(payment: any): Observable<any> {
    return this.http.put<any>('CommissionPay/update', payment)
  }
}
