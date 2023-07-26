import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import {  Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router} from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  public users:any;
  public signupForm! :FormGroup;
  bookingResult: string='';


  constructor(private formBuilder:FormBuilder, private authService: AuthService,private http:HttpClient, private router:Router){  }
  
  
ngOnInit(): void {
  this.bus();
  this.validate();
}
private bus():void{
  this.signupForm=this.formBuilder.group({
    // userId:[],
    name:[],
    email:[],
    mobile:[] ,
    pwd:[]
  });
}

private validate(): void
{
  this.signupForm = this.formBuilder.group({
    // userId:['',[Validators.required,Validators.pattern("[0-9]*")]],
    name:['',[Validators.required,Validators.minLength(3),Validators.pattern("[a-zA-Z].*")]],
    email:['',[Validators.required,Validators.email]],
    mobile:['',[Validators.required,Validators.pattern("[0-9]*"),Validators.minLength(10),Validators.maxLength(10)]],
    pwd:['',[Validators.required,Validators.minLength(6)]]
    
  });
}


public AddNewUser(): void
{
  this.authService.AddNewUser (this.signupForm.value)
  .subscribe(result =>{
    this.bookingResult = "Your account created successfully. Now you can go and book your tickets.";
  });
}




get Name(): FormControl{
return this.signupForm.get("name") as FormControl;
}
get Email(): FormControl{
  return this.signupForm.get("email") as FormControl;
}
get Mobile(): FormControl{
  return this.signupForm.get("mobile") as FormControl;
}
get Pwd(): FormControl{
  return this.signupForm.get("pwd") as FormControl;
}

 
}


