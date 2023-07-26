import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';


import { BusselectionComponent } from './busselection/busselection.component';
import { MainPageComponent } from './main-page/main-page.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { HomeComponent } from './home/home.component';
import { PdfpageComponent } from './pdfpage/pdfpage.component';
import { AdminLoginComponent } from './admin-login/admin-login.component';
import { AdminpageComponent } from './adminpage/adminpage.component';
import { EmailComponent } from './email/email.component';
// import { AuthService } from './services/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    BusselectionComponent,
    MainPageComponent,
    LoginComponent,
    SignupComponent,
    HomeComponent,
    PdfpageComponent,
    AdminLoginComponent,
    AdminpageComponent,
    EmailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
