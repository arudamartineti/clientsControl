import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IContact } from '../interfaces/contact';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  private apiUrl = this.baseUrl + "api/contacts";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getContacts(): Observable<IContact[]> {
    return this.http.get<IContact[]>(this.apiUrl);
  }

  getContact(id: string): Observable<IContact> {
    return this.http.get<IContact>(this.apiUrl + '/' + id);
  }

  createContact(contact: IContact): Observable<IContact> {
    return this.http.post<IContact>(this.apiUrl, contact);
  }

  updateContact(id: string, contact: IContact): Observable<IContact> {
    return this.http.put<IContact>(this.apiUrl + '/' + id, contact);
  }

  deleteContact(id: string): Observable<boolean> {
    return this.http.delete<boolean>(this.apiUrl + '/' + id);    
  }
}
