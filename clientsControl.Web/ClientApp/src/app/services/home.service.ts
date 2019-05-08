import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { ILicenseStatics } from '../interfaces/license-statics';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  private apiUrl = this.baseUrl + "api/home";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getStatics(): Observable<ILicenseStatics> {
    return this.http.get<ILicenseStatics>(this.apiUrl);
  }
}
