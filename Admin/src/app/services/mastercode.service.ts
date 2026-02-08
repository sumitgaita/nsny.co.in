import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class MasterCodeService {
  constructor(private http: HttpService) { }

  getAllMasterCode(): Observable<any> {
    return this.http.get<any>('MasterCode');
  }

  updateMasterCode(mastercodeObject: any): Observable<any> {
    return this.http.put<any>('MasterCode/update', mastercodeObject)
  }

  createMasterCode(mastercodeObject: any): Observable<any> {
    return this.http.post<any>('MasterCode', mastercodeObject)
  }

  deleteMasterCode(mastercodeid: number): Observable<any> {
    return this.http.delete<any>('MasterCode?mastercodeid=' + mastercodeid)
  }
  
}
