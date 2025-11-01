import { Injectable } from '@angular/core';
//import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { HttpService } from './http.service';

//const API_URL = 'http://localhost/nsym.service/api/Course';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(//private http: HttpClient,
    private http: HttpService) { }

  getAllCourse(): Observable<any> {
    return this.http.get<any>('Course');
  }

  GetAllActiveCourse(): Observable<any> {
    return this.http.get<any>('Course?active=' + '');
  }

  GetByIdCourse(couseId: number): Observable<any> {
    return this.http.get<any>('Course?couseId=' + couseId);
  }

  updateCourse(courseObject: any): Observable<any> {
    return this.http.put<any>('Course/update', courseObject)
  }

  createCourse(courseObject: any): Observable<any> {
    return this.http.post<any>('Course', courseObject)
  }

  deleteCourse(courseId: number): Observable<any> {
    return this.http.delete<any>('Course?courseId=' + courseId)
  }
  //createCourse(courseObject: any): Observable<any> {
  //  // return this.http.post<any>('Course', courseObject)
  //  return this.http.post<any>(API_URL, JSON.stringify(courseObject), { headers: this.getRequestHeader() })
  //    .pipe(tap((res: any) => {
  //    }, (error: HttpErrorResponse) => {
  //    }),
  //    );
  //}

 
  //private getRequestHeader(): HttpHeaders {
  // // this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
  //  return new HttpHeaders({
  //    'Content-Type': 'application/json',
  //    //'Authorization': 'Bearer ' + this.currentUser.access_token,
  //    'Cache-Control': 'no-cache',
  //    'If-Modified-Since': '0'
  //  });
 // }
}
