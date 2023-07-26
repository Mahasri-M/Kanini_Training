import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  successMessage: boolean = false;
  errorMessage: string = '';
  public loginForm! :FormGroup;
  constructor(private authService: AuthenticationService,private router:Router,private formBuilder:FormBuilder) { }
  ngOnInit() {
    this.validate();
  }

  login(email: string, pwd: string): void {
    this.authService.signIn(email, pwd).subscribe(
   response => {
    this.successMessage = true;
    setTimeout(() => {
      this.successMessage = false;
      localStorage.setItem('userstudent', email);
      const token = response; 
      console.log(token);
      const tokenString = JSON.stringify(token);
      localStorage.setItem('token', tokenString);
    }, 3000);
        
       
    },
      error => {
        console.log(error);
        if (error?.error?.errors) {
          this.errorMessage = error.error.errors;
        }
      }
    );
  }
  closePopup(): void {
    this.successMessage = false;
    this.errorMessage = '';
    this.router.navigateByUrl('/courseviewuser')
  }
 
  private validate(): void
  {
    this.loginForm = this.formBuilder.group({
      email:['',[Validators.required,Validators.email]],
      pwd:['',[Validators.required,Validators.minLength(6)]]
      
    });
  }
  get Email(): FormControl{
    return this.loginForm.get("email") as FormControl;
  }
  
  get Pwd(): FormControl{
    return this.loginForm.get("pwd") as FormControl;
  }
}
