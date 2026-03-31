import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class StudentService {
  constructor(private http: HttpService) { }

  getStudent(nssy_code: string): Observable<any> {
    return this.http.get<any>('Student?nssy_code=' + nssy_code);
  }

  getCenterCodeStudent(nssy_code: string, centerid: string, logintype: string): Observable<any> {
    return this.http.get<any>('Student?center_code=' + nssy_code + '&logintype=' + logintype + '&centerid=' + centerid);
  }

  getStudentVerification(name: string, nssy_code: string): Observable<any> {
    return this.http.outSiteGet<any>('Upload?name=' + name + '&nssy_code=' + nssy_code);
  }
  getBranchViewStudent(branchId: number, centerId: string, logintype: string, fromdate: string, todate: string): Observable<any> {
    return this.http.get<any>('Student?branchId=' + branchId + '&centerId=' + centerId + '&logintype=' + logintype + '&fromdate=' + fromdate + '&todate=' + todate);
  }

  updateStudent(studentObject: any): Observable<any> {
    return this.http.put<any>('Student/update', studentObject)
  }

  createStudent(studentObject: any): Observable<any> {
    return this.http.post<any>('Student', studentObject)
  }

  deleteStudent(studentId: number): Observable<any> {
    return this.http.delete<any>('Student?studentId=' + studentId)
  }

  branchStudentRegisCount(centercode: string, nssycode: string): Observable<any> {
    return this.http.get<any>('Student?centercode=' + centercode + '&nssycode=' + nssycode)
  }

  uploadStudentImage(studentObject: any): Observable<any> {
    return this.http.upload<any>('Upload', studentObject)
  }

  getAdminVerifyStudent(): Observable<any> {
    return this.http.get<any>('AdminCertificate');
  }

  getStudentIDJdate(nssy_code: string): Observable<any> {
    return this.http.get<any>('AdminCertificate?nssy_code=' + nssy_code);
  }
}
