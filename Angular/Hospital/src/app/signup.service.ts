import { HttpClient } from "@angular/common/http";
import { registerModel } from "../app/register/model/register.model";
import { UserDTOModel } from "../app/register/model/userDTO.model";
import {Injectable} from '@angular/core';

import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class SignupService{
  private baseServerUrl = "https://localhost:7239/api/Specializations";
  private doctorUrl="https://localhost:7239/api/Users/filteringdoctors";
  private patientUrl="https://localhost:7239/api/Users/filteringpatient";
  private imgUrl="https://localhost:7225/api/Image";
    constructor(private httpClient:HttpClient)
    {

    }

    signup(register:registerModel){
        console.log("register in service")
        return this.httpClient.post("https://localhost:7239/api/User/Register",register);
    }

    userLogin(userDTO:UserDTOModel){
        return this.httpClient.post("https://localhost:7239/api/User/Login",userDTO);
    }


    private formDetailsSubject = new BehaviorSubject<any>(null);
  formDetails$ = this.formDetailsSubject.asObservable();

  setFormDetails(details: any) {
    this.formDetailsSubject.next(details);
  }
  public getAllSpecifications():Observable<any>
  {
    return this.httpClient.get(this.baseServerUrl);
  }

  public getAllDoctors():Observable<any>{
    return this.httpClient.get(this.doctorUrl);
  }

  public getAllUsers():Observable<any>{
    return this.httpClient.get(this.patientUrl);
  }
  public DeleteUser(id:number):Observable<any>{
    return this.httpClient.delete(`https://localhost:7239/api/Users/${id}`);
  }

  public DeleteDoctor(id:number):Observable<any>{
    return this.httpClient.delete(`https://localhost:7239/api/Users/${id}`);
  }
public GetImg():Observable<any>{
  return this.httpClient.get(this.imgUrl);
}

}