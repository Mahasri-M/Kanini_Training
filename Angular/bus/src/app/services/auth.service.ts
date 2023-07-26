import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseServerUrl = "https://localhost:44382/api/User";
  private bookUrl="https://localhost:44382/api/Booking";
  private busUrl="https://localhost:44382/api/Bus";
  constructor(private http: HttpClient) { }

  public getAllUsers():Observable<any>
  {
    
    return this.http.get(this.baseServerUrl);
  }

  public getAllBookings():Observable<any>
  {
    return this.http.get(this.bookUrl);
  }
  public getAllBuses():Observable<any>
  {
    return this.http.get(this.busUrl);
  }

  public AddNewUser(bus : any):Observable<any>
    {
      return this.http.post(this.baseServerUrl, bus);
    }

   public AddNewBus(bus: any):Observable<any>
   {
      return this.http.post(this.busUrl,bus);
   }

public submitPassengerDetails(book:any):Observable<any>
{
  return this.http.post(this.bookUrl,book);
}

public DeleteUser(id:number):Observable<any>{
  return this.http.delete(`https://localhost:44382/api/User/${id}`);
}

public DeleteBooking(id:number):Observable<any>{
  return this.http.delete(`https://localhost:44382/api/Booking/${id}`);
}
public DeleteBus(id:number):Observable<any>{
  return this.http.delete(`https://localhost:44382/api/Bus/${id}`);
}

fetchDetails(boarding: string, destination: string) {
  const url = `https://localhost:44382/api/Bus/filterbyboardingdestination?boarding=${boarding}&destination=${destination}`;
  return this.http.get(url);
}
public UpdateUser(id:number, bus:any)
{
  const url = `${this.baseServerUrl}/${id}`;
  return this.http.put(url , bus);
}
public Updatebooking(id:number, bus:any)
{
  const url = `${this.bookUrl}/${id}`;
  return this.http.put(url , bus);
}
public Updatebus(id:number, bus:any)
{
  const url = `${this.busUrl}/${id}`;
  return this.http.put(url , bus);
}


  // signupUser(){
  //  return this.http.post(this.baseServerUrl , null,{
  //   responseType: 'text'
  //  });
  // }
  // public getStudentsById(id:number):Observable<any>
  // {
  //   var path = this.basepath + "/api/Student" + id;
  //   console.log(path)
  //   return this.http.get(path);
  // }

  // public AddNewStudent(student : any):Observable<any>
  // {
  //   return this.http.post(this.basepath + "/api/Student", student);
  // }

}
