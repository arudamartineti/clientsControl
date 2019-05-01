import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpEvent, HttpHandler, HttpResponse, HttpSentEvent } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { AccountsService } from './accounts.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationInterceptorService implements HttpInterceptor {

  constructor(private accountService: AccountsService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var token = this.accountService.getToken();

    req = req.clone({
      setHeaders: { Authorization: "bearer " + token }
    });

    return next.handle(req);
  }    
  
}
