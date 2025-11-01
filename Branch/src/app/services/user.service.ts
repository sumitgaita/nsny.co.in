import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders,HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
const AUTH_API = 'http://localhost/nsym.service/token';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class UserService {
  user:any=null;
  constructor(private http: HttpClient) { }

  

  login<T>(username: string, password: string, loginType: string): Observable<T> {
    const body = new HttpParams()
      .set('grant_type', 'password')
      .set('username', (loginType + '$' + username))
      .set('password', password)
      .set('loginType', loginType)
    return this.http.post<T>(AUTH_API, body.toString(),
       httpOptions
    );

  }
  getUser(){
    return this.user;
  }


}
