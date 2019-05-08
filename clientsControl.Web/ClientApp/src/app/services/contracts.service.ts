import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IContract } from '../interfaces/contract';

@Injectable({
  providedIn: 'root'
})
export class ContractsService {

  private apiUrl = this.baseUrl + "api/contracts";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getContracts(): Observable<IContract[]> {
    return this.http.get<IContract[]>(this.apiUrl);
  }

  getContract(id: string): Observable<IContract> {
    return this.http.get<IContract>(this.apiUrl + "/" +  id);
  }

  createContract(contract: IContract): Observable<IContract> {
    return this.http.post<IContract>(this.apiUrl, contract);
  }

  updateContract(id: string, contract: IContract): Observable<IContract> {
    return this.http.put<IContract>(this.apiUrl + "/" + id, contract);
  }

  deleteContract(id: string): Observable<any> {
    return this.http.delete(this.apiUrl + "/" + id);
  }

  discontinueContract(id: string): Observable<any> {
    return this.http.post(this.apiUrl + "/discontinue", id);
  }  
}
