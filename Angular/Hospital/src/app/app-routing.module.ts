import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { AdminpageComponent } from './adminpage/adminpage.component';
import { LoginComponent } from './login/login.component';
import { HomepageComponent } from './homepage/homepage.component';

const routes: Routes = [
  {path:'register',component:RegisterComponent},
  {path:'adminpage',component:AdminpageComponent},
  {path:'login',component:LoginComponent},
  {path:'homepage',component:HomepageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
