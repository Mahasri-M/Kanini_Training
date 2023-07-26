import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http:HttpClient) { }
  //User Login 
  signIn(email: string, pwd: string) {
    const signInData = { email, pwd };
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      responseType: 'text' as 'json' 
    };

    return this.http.post<string>('https://localhost:44382/api/Token', signInData, httpOptions)
      .pipe(
        tap(jwtUserToken => {
          localStorage.setItem('jwtUserToken', jwtUserToken);
        })
      );
  }

  getToken()
  {
    return localStorage.getItem('jwtUserToken');
  }

}

