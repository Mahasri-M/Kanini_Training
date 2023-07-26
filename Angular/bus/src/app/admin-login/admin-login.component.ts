// import { Component,OnInit } from '@angular/core';
// import {  FormControl, Validators } from '@angular/forms';
// import { FormGroup, FormBuilder } from '@angular/forms';


// @Component({
//   selector: 'app-admin-login',
//   templateUrl: './admin-login.component.html',
//   styleUrls: ['./admin-login.component.css']
// })
// export class AdminLoginComponent  implements OnInit{
//   public adminform! :FormGroup;
//   constructor(private formBuilder:FormBuilder){}
//   ngOnInit(): void {
//     this.validate();
//     this.adminLogin();
//   }
//   private validate(): void
// {
//   this.adminform = this.formBuilder.group({
//     name:['',[Validators.required,Validators.minLength(3),Validators.pattern("[a-zA-Z].*")]],
//     pwd:['',[Validators.required,Validators.minLength(6)]]
    
//   });
// }

// adminLogin(): void {
//   if (this.adminform.valid) {
//     const name = this.adminform.value.name;
//     const password = this.adminform.value.pwd;

//     if (name === 'maha' && password === 'maha@5555') {
//       console.log('Login successful');
//     } else {
//       console.log('Invalid credentials');
//     }
//   }
// }

// get Name(): FormControl{
//   return this.adminform.get("name") as FormControl;
//   }

//   get Pwd(): FormControl{
//     return this.adminform.get("pwd") as FormControl;
//   }
// }


// import { Component, OnInit } from '@angular/core';
// import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
// import { Router} from '@angular/router';
// @Component({
//   selector: 'app-admin-login',
//   templateUrl: './admin-login.component.html',
//   styleUrls: ['./admin-login.component.css']
// })
// export class AdminLoginComponent implements OnInit {
//   public adminform!: FormGroup;
//   adminDetails:any={
   
//     name:'',
//     pwd:''
//   };

//   constructor(private formBuilder: FormBuilder,private router:Router) { }

//   ngOnInit(): void {
//     this.validate();
//   }

//   private validate(): void {
//     this.adminform = this.formBuilder.group({
//       name: ['', [Validators.required, Validators.minLength(3), Validators.pattern("[a-zA-Z].*")]],
//       pwd: ['', [Validators.required, Validators.minLength(6)]]
//     });
//   }

//   adminLogin(): void {
//     if (this.adminform.valid) {
//       const name = this.adminform.value.name;
//       const password = this.adminform.value.pwd;

//       if (name === 'maha' && password === 'maha@5555') {
//         console.log('Login successful');
//       } else {
//         console.log('Invalid credentials');
//       }
//     }
//   }

//   get Name(): FormControl {
//     return this.adminform.get('name') as FormControl;
//   }

//   get Pwd(): FormControl {
//     return this.adminform.get('pwd') as FormControl;
//   }
// }



import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrls: ['./admin-login.component.css']
})
export class AdminLoginComponent implements OnInit {
  public adminform!: FormGroup;

  constructor(private formBuilder: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.validate();
  }

  private validate(): void {
    this.adminform = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3), Validators.pattern("[a-zA-Z].*")]],
      pwd: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  adminLogin(): void {
    if (this.adminform.valid) {
      const name = this.adminform.value.name;
      const password = this.adminform.value.pwd;

      if (name === 'maha' && password === 'maha@5555') {
        console.log('Login successful');
        this.router.navigate(['/adminpage']); 
      } else {
        alert('Invalid credentials');
      }
    }
  }

  get Name(): FormControl {
    return this.adminform.get('name') as FormControl;
  }

  get Pwd(): FormControl {
    return this.adminform.get('pwd') as FormControl;
  }
}
