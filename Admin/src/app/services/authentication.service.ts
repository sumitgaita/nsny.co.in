import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpService } from './http.service';
import { AdminLogin } from 'src/app/model/AdminLogin';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private currentUserSubject: BehaviorSubject<AdminLogin | null>;
  public currentUser: Observable<AdminLogin | null>;

  constructor(private http: HttpService) {
    this.currentUserSubject = new BehaviorSubject<AdminLogin | null>(JSON.parse(localStorage.getItem('currentUser') || '{}'));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): AdminLogin | null {
    return this.currentUserSubject.value;
  }

  login(username: string, password: string, loginType: string): Observable<any> {
    return this.http.getLoginToken<any>(username, password, loginType)
      .pipe(map(adminLogin => {
        adminLogin.id = Number(adminLogin.id);
        adminLogin.loginType = loginType;
        if (adminLogin.id > 0) {
          localStorage.setItem('currentUser', JSON.stringify(adminLogin));
          this.currentUserSubject.next(adminLogin);
          return adminLogin;
        }
      }));
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
  changeBranchPassword(id: number, password: string): Observable<any> {
    return this.http.get<any>('Login?id=' + id + '&password=' + password);
  }
  changeAdminPassword(id: number, username: string, password: string): Observable<any> {
    return this.http.get<any>('Login?id=' + id + '&username=' + username + '&password=' + password);
  }
}
