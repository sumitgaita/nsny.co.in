import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class WalletService {
  constructor(private http: HttpService) { }

  //getStudent(nssy_code: string): Observable<any> {
  //  return this.http.get<any>('Student?nssy_code=' + nssy_code);
  //}

  //getCenterCodeStudent(nssy_code: string): Observable<any> {
  //  return this.http.get<any>('Student?center_code=' + nssy_code + '&name=' + 0);
  //}

  getWalletHistoryDetails(branchId: number, paymentNote: string): Observable<any> {
    return this.http.get<any>('Wallet?branchId=' + branchId + '&paymentNote=' + paymentNote);
  }
  GetBranchWallet(branchId: number): Observable<any> {
    return this.http.get<any>('Wallet?branchId=' + branchId);
  }

  //updateStudent(studentObject: any): Observable<any> {
  //  return this.http.put<any>('Student/update', studentObject)
  //}
  getAllWalletBranch(): Observable<any> {
    return this.http.get<any>('Wallet');
  }
  createWallet(walletObject: any): Observable<any> {
    return this.http.post<any>('Wallet', walletObject)
  }

  //deleteStudent(studentId: number): Observable<any> {
  //  return this.http.delete<any>('Student?studentId=' + studentId)
  //}

  //branchStudentRegisCount(centercode: string, nssycode: string): Observable<any> {
  //  return this.http.get<any>('Student?centercode=' + centercode + '&nssycode=' + nssycode)
  //}

  //uploadStudentImage(studentObject: any): Observable<any> {
  //  return this.http.upload<any>('Upload', studentObject)
  //}

  //getAdminVerifyStudent(): Observable<any> {
  //  return this.http.get<any>('AdminCertificate');
  //}

  //getStudentIDJdate(nssy_code: string): Observable<any> {
  //  return this.http.get<any>('AdminCertificate?nssy_code=' + nssy_code);
  //}
}
