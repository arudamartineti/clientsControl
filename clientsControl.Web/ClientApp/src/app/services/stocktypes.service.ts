import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IStocktypes } from '../interfaces/stocktypes';

@Injectable({
  providedIn: 'root'
})
export class StocktypesService {
  private apiUrl = this.baseUrl + "api/stocktypes";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getStockTypes(): Observable<IStocktypes[]> {
    return this.http.get<IStocktypes[]>(this.apiUrl);
  }

  getStockType(id: string): Observable<IStocktypes> {
    return this.http.get<IStocktypes>(this.apiUrl + '/' + id);
  }

  createStockType(module: IStocktypes): Observable<IStocktypes> {
    return this.http.post<IStocktypes>(this.apiUrl, module);
  }

  updateStockType(id: string, module: IStocktypes): Observable<IStocktypes> {
    return this.http.put<IStocktypes>(this.apiUrl + '/' + id, module);
  }

  deleteStockType(id: string): Observable<IStocktypes> {
    return this.http.delete<IStocktypes>(this.apiUrl + '/' + id);
  }
}
