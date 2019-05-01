import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IConfiguration } from '../interfaces/configuration';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  private apiUrl = this.baseUrl + "api/configuration";


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getConfiguration(): Observable<IConfiguration> {
    return this.http.get<IConfiguration>(this.apiUrl);
  }

  setConfiguration(configuration: IConfiguration): Observable<IConfiguration> {
    return this.http.post<IConfiguration>(this.apiUrl, configuration);
  }

}
