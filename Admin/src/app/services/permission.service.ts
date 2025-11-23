import { EventEmitter, Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class PermissionService {
  static onEditPermissionRow = new EventEmitter<any>();
  constructor(private http: HttpService) { }

  getAllPermission(): Observable<any> {
    return this.http.get<any>('UserPermission');
  }

  updatePermission(permissionObject: any): Observable<any> {
    return this.http.put<any>('UserPermission/update', permissionObject)
  }

  createPermission(permissionObject: any): Observable<any> {
    return this.http.post<any>('UserPermission', permissionObject)
  }

  deletePermission(id: number): Observable<any> {
    return this.http.delete<any>('UserPermission?id=' + id)
  }
  
}
