import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IUser } from '../interfaces/user';
import { Observable } from 'rxjs';
import { IUserRole } from '../interfaces/user-role';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private apiUrl = this.baseUrl + "api/users";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getUsers(): Observable<IUser[]> {
    return this.http.get<IUser[]>(this.apiUrl);
  }

  getUser(id: string): Observable<IUser> {
    return this.http.get<IUser>(this.apiUrl + '/' + id);
  }

  authorizeUser(id: string, user: IUser): Observable<boolean> {
    return this.http.put<boolean>(this.apiUrl + '/' + id, user);
  }

  registerUser(user: IUser) : Observable<IUser> {
    return this.http.post<IUser>(this.baseUrl + "api/account/register", user);
  }

  setUserRoles(idUser: string, userRoles: IUserRole): Observable<IUser> {
    return this.http.post<IUser>(this.apiUrl + '/' + idUser + '/roles', userRoles);
  }
}
