import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IClient } from '../interfaces/client';

@Injectable()
export class ClientsService {
  private apiUrl = this.baseUrl + "api/clients";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  getClients(): Observable<IClient[]> {
    return this.http.get<IClient[]>(this.apiUrl);
  }

  getClient(id: string): Observable<IClient> {
    return this.http.get<IClient>(this.apiUrl + "/" + id);
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

