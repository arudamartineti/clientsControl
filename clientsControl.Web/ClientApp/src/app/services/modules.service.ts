import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IModule } from '../interfaces/module';

@Injectable({
  providedIn: 'root'
})
export class ModulesService {
  private apiUrl = this.baseUrl + "api/modules";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getModules(): Observable<IModule[]> {
    return this.http.get<IModule[]>(this.apiUrl);
  }

  getModule(id: string) : Observable<IModule> {
    return this.http.get<IModule>(this.apiUrl + '/' + id);
  }

  createModule(module: IModule): Observable<IModule> {
    return this.http.post<IModule>(this.apiUrl, module);
  }

  updateModule(id: string, module: IModule): Observable<IModule> {
    return this.http.put<IModule>(this.apiUrl + '/' + id, module);
  }

  deleteModule(id: string): Observable<IModule> {
    return this.http.delete<IModule>(this.apiUrl + '/' + id);
  }
 

}
