import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class DashBoardService {
  constructor(private http: HttpService) { }

  getAllCount(): Observable<any> {
    return this.http.get<any>('dashboard');
  }
  getAllBranchCount(Center_code: string, likestr: string): Observable<any> {
    return this.http.get<any>('dashboard?Center_code=' + Center_code + '&likestr=' + likestr);
  }
   getAllImages(name?: string, nssycode?: string,centercode?: string): Observable<any> {
     const params = {
    name: name ?? null,
    nssycode: nssycode ?? null,
    centercode: centercode ?? null
  };
    return this.http.get<any>('dashboard/image?name=' + params.name + '&nssycode=' + params.nssycode+ '&centercode=' + params.centercode);
  }
}
