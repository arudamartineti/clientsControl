import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IClient } from '../interfaces/client';
import { IClientLicenseClasification } from '../interfaces/client-license-clasification';

@Injectable()
export class ClientsService {
  private apiUrl = this.baseUrl + "api/clients";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  getClients(): Observable<IClient[]> {
    return this.http.get<IClient[]>(this.apiUrl);
  }

  getClientsSelect(): Observable<IClient[]> {
    return this.http.get<IClient[]>(this.apiUrl + '/select');
  }

  getClient(id: string): Observable<IClient> {
    return this.http.get<IClient>(this.apiUrl + "/" + id);
  }

  getClientClasifications(id: string): Observable<IClientLicenseClasification[]> {
    return this.http.get<IClientLicenseClasification[]>(this.apiUrl + "/clasifications/" + id);
  }

  createClient(client: IClient): Observable<IClient> {
    return this.http.post<IClient>(this.apiUrl, client);
  }

  updateClient(id: string, client: IClient): Observable<IClient> {
    return this.http.put<IClient>(this.apiUrl + "/" + id, client);
  }

  deleteClient(id: string): Observable<boolean> {
    return this.http.delete<boolean>(this.apiUrl + "/" + id);
  }

}

