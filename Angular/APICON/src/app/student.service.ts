import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn:'root'
})
export class StudentService{
    private basepath = "https://localhost:44343/Student";

    constructor(private http:HttpClient) { }
  
    public getAllStudents():Observable<any>
    {
      return this.http.get(this.basepath );
    }
  
  
    public getStudentsById(id:number):Observable<any>
    {
      return this.http.get(`https://localhost:44343/Student/${id}`);
      // var path = this.basepath + "/Student" + id;
      // console.log(path)
      // return this.http.get(path);
    }
  
    public AddNewStudent(student : any):Observable<any>
    {
      return this.http.post(this.basepath, student);
    }

    public UpdateStudent(id:number, student:any)
    {
      const url = `${this.basepath}/${id}`;
      return this.http.put(url , student);
    }
    public DeleteStudentById(id:number):Observable<any>{
      return this.http.delete(`https://localhost:44343/Student/${id}`);
    }
  }
