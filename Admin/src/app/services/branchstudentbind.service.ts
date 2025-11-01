import { Injectable, EventEmitter } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class BranchstudentbindService {
  // openPaymentPopup = new EventEmitter<any>();
  static onEditPaymentRow = new EventEmitter<any>();
  static onEditReceiptRow = new EventEmitter<any>();
  static onViewReceiptRow = new EventEmitter<any>();
  static onDeleteNotice = new EventEmitter<any>();
  constructor(private http: HttpService) { }



  createbranchstudentbind(courseObject: any): Observable<any> {
    return this.http.post<any>('BranchStudentBind', courseObject);
  }
  createPaymentCollection(paymentCollectionObject: any): Observable<any> {
    return this.http.post<any>('PaymentCollection', paymentCollectionObject);
  }
  paymentLastUpdate(paymentObject: any): Observable<any> {
    return this.http.put<any>('PaymentCollection/update', paymentObject);
  }
  getPaymentCollection(branchId: number): Observable<any> {
    return this.http.get<any>('BranchStudentBind?branchId=' + branchId);
  }
  getPaymentPrintDetails(stid: string): Observable<any> {
    return this.http.get<any>('BranchStudentBind?stid=' + stid);
  }
  getPaymenCount(branchId: number, dt: string): Observable<any> {
    return this.http.get<any>('BranchStudentBind?branchId=' + branchId + '&dt=' + dt);
  }
  getBranchPaymenteraning(branchId: number, fromdate: string, todate: string): Observable<any> {
    return this.http.get<any>('BranchStudentBind?branchId=' + branchId + '&fromdate=' + fromdate + '&todate=' + todate);
  }

  getStuRegistrationList(branchId: number, fromdate: string, todate: string): Observable<any> {
    return this.http.get<any>('PaymentCollection?branchId=' + branchId + '&fromdate=' + fromdate + '&todate=' + todate);
  }

  getAdminStudentIcard(branchId: number, fromdate: string, todate: string): Observable<any> {
    return this.http.get<any>('PaymentCollection?branchId=' + branchId + '&fromdate=' + fromdate + '&todate=' + todate + '&studentId=' + 0);
  }
  getAdminPaymentCollectionResult(branchId: number, fromdate: string, todate: string): Observable<any> {
    return this.http.get<any>('AdminPaymentCollection?branchId=' + branchId + '&fromdate=' + fromdate + '&todate=' + todate);
  }
  getViewEarningDetails(branchId: number, fromdate: string, todate: string): Observable<any> {
    return this.http.get<any>('AdminPaymentCollection?branchId=' + branchId + '&fromdate=' + fromdate + '&todate=' + todate + '&studentId=' + 0);
  }
  getCourseBindList(stid: string): Observable<any> {
    return this.http.get<any>('StudentCourseBind?stid=' + stid);
  }
  studentCourseBindUpdate(studentcourse: any): Observable<any> {
    return this.http.put<any>('BranchStudentBind/update', studentcourse);
  }
  getAllNotification(): Observable<any> {
    return this.http.get<any>('Notification');
  }
  deleteNotification(notificationid: number): Observable<any> {
    return this.http.delete<any>('Notification/deleteNotification?id=' + notificationid)
  }
}
