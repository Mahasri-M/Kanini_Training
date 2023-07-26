import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';
import { BusselectionComponent } from './busselection/busselection.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { HomeComponent } from './home/home.component';
import { PdfpageComponent } from './pdfpage/pdfpage.component';
import { AdminLoginComponent } from './admin-login/admin-login.component';
import { AdminpageComponent } from './adminpage/adminpage.component';
import { EmailComponent } from './email/email.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {path: 'home', component:HomeComponent},
  {path: 'home/admin-login',component:AdminLoginComponent},
  {path: 'home/admin-login/adminpage', component:AdminpageComponent},
  {path: 'home/signup', component:SignupComponent},
  {path: 'home/signup/main',component:MainPageComponent},
  {path: 'home/signup/login',component:LoginComponent},
  {path: 'signup/login', component:LoginComponent},
  {path: 'login/signup', component:SignupComponent},
  {path: 'signup/login', component:LoginComponent},
  {path:'login/main',component:MainPageComponent},
  {path: 'main', component: MainPageComponent },
  { path: '', redirectTo: 'busselection', pathMatch: 'full' },
  {path: 'busselection', component: BusselectionComponent },
  {path: 'pdfpage', component:PdfpageComponent},
  {path: 'busselection/pdfpage', component:PdfpageComponent},
  {path:'email',component:EmailComponent}
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  // declarations: []
})
export class AppRoutingModule { }
