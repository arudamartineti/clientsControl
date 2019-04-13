import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IClient } from '../interfaces/client';
import { IAssetsversion } from '../interfaces/assetsversion';

//@Injectable({
//  providedIn: 'root'
//})
@Injectable()
export class AssetsversionService {
  private apiUrl = this.baseUrl + "api/assetsversions";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAssetsVersions(): Observable<IAssetsversion[]> {
    return this.http.get<IAssetsversion[]>(this.apiUrl);
  }

  getAssetsVersion(id: string): Observable<IAssetsversion> {
    return this.http.get<IAssetsversion>(this.apiUrl + '/' + id);
  }

  createAssetsVersion(assetsVersion: IAssetsversion): Observable<IAssetsversion> {
    return this.http.post<IAssetsversion>(this.apiUrl, assetsVersion);
  }

  updateAssetsVersion(id: string, assetsVersion: IAssetsversion): Observable<IAssetsversion> {
    return this.http.put<IAssetsversion>(this.apiUrl + '/' + id, assetsVersion);
  }

  deleteAssetsVersion(id: string): Observable<boolean> {
    return this.http.delete<boolean>(this.apiUrl + '/' + id);
  }
}
