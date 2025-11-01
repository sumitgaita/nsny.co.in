import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class BranchService {
  constructor(private http: HttpService) { }

  getAllBranch(): Observable<any> {
    return this.http.get<any>('Branch');
  }

  updateBranch(branchObject: any): Observable<any> {
    return this.http.put<any>('Branch/update', branchObject)
  }

  createBranch(branchObject: any): Observable<any> {
    return this.http.post<any>('Branch', branchObject)
  }

  deleteBranch(branchId: number): Observable<any> {
    return this.http.delete<any>('Branch?branchId=' + branchId)
  }
  currntBranchId(): Observable<any> {
    return this.http.get<any>('Branch?currentId=' + 0);
  }

  createBranchNotification(notificationObject: any): Observable<any> {
    return this.http.post<any>('Notification', notificationObject)
  }
  getBranchNotification(bid: number): Observable<any> {
    return this.http.get<any>('Notification?bid=' + bid);
  }
}
