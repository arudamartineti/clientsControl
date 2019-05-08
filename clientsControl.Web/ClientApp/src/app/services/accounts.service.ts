import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IUser } from '../interfaces/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  private apiUrl = this.baseUrl + "api/account";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  registerUser(user: IUser): Observable<IUser> {
    return this.http.post<IUser>(this.baseUrl + "api/account/register", user);
  }

  loginUser(user: IUser): Observable<any> {
    return this.http.post<any>(this.baseUrl + "api/account/login", user);
  }

  getToken(): string {
    return localStorage.getItem("securityToken");
  }

  getTokenExpiration(): string {
    return localStorage.getItem("secutiryTokenExpiration");
  }

  logoutUser() {
    this.http.get<any>(this.baseUrl + "api/account/logout");
    localStorage.removeItem("securityToken");
    localStorage.removeItem("secutiryTokenExpiration");
  }

  isLogued(): boolean {
    var expiration = this.getTokenExpiration();

    if (!expiration)
      return false;

    var nowTime = new Date().getTime();
    var expirationTime = new Date(expiration);

    if (nowTime >= expirationTime.getTime()) {
      this.logoutUser();
      return false;
    }
    return true;
  }



}
