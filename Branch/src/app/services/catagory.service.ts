import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CatagoryService {
  constructor(private http: HttpService) { }

  getAllCatagory(): Observable<any> {
    return this.http.get<any>('Catagory');
  }

  updateCatagory(branchObject: any): Observable<any> {
    return this.http.put<any>('Catagory/update', branchObject)
  }

  createCatagory(branchObject: any): Observable<any> {
    return this.http.post<any>('Catagory', branchObject)
  }

  deleteCatagory(catagoryId: number): Observable<any> {
    return this.http.delete<any>('Catagory?catagoryId=' + catagoryId)
  }
  
}
