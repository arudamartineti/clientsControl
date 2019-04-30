import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRole } from '../interfaces/role';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  private apiUrl = this.baseUrl + "api/users/roles";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getRoles() : Observable<IRole[]> {
    return this.http.get<IRole[]>(this.apiUrl);
  }
}
