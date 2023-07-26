import { Injectable, Injector } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private injector:Injector) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let auth=this.injector.get(AuthenticationService);
    let tokenizedReq=req.clone({
      setHeaders:{
        Authorization: `Bearer ${auth.getToken()}`      }
    });
    return next.handle(tokenizedReq);
  }
}





  
 