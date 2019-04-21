import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ILicense } from '../interfaces/license';

@Injectable({
  providedIn: 'root'
})
export class LicenseService {

  private apiUrl = this.baseUrl + "api/licenses";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getLicenses(): Observable<ILicense[]> {
    return this.http.get<ILicense[]>(this.apiUrl);
  }

  getLicensesSelect(): Observable<ILicense[]> {
    return this.http.get<ILicense[]>(this.apiUrl + '/select');
  }

  getLicensesClientSelect(id:string): Observable<ILicense[]> {
    return this.http.get<ILicense[]>(this.apiUrl + '/client/' + id + '/select');
  }  

  getLicense(id: string): Observable<ILicense> {
    return this.http.get<ILicense>(this.apiUrl + '/' + id);
  }

  createLicense(license: ILicense): Observable<ILicense> {
    return this.http.post<ILicense>(this.apiUrl, license);
  }

  updateLicense(id: string, license: ILicense): Observable<ILicense> {
    return this.http.post<ILicense>(this.apiUrl + '/' + id, license);
  }

  deleteLicense(id: string): Observable<boolean> {
    return this.http.delete<boolean>(this.apiUrl + '/' + id);
  }
}
