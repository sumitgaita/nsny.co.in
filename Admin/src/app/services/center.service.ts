import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CenterService {
  constructor(private http: HttpService) { }

  updateCenter(branchObject: any): Observable<any> {
    return this.http.put<any>('Center/update', branchObject)
  }

  createCenter(branchObject: any): Observable<any> {
    return this.http.post<any>('Center', branchObject)
  }

  deleteCenter(branchId: number): Observable<any> {
    return this.http.delete<any>('Center?branchId=' + branchId)
  }
  currntCenterId(bid: number): Observable<any> {
    return this.http.get<any>('Center/currentcenter?currentId=' + bid);
  }

  
  getBranchCenter(bid: number): Observable<any> {
    return this.http.get<any>('Center?bid=' + bid);
  }
}
