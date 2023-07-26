import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerlistComponent } from './customerlist/customerlist.component';
import { CustomerdetailComponent } from './customerdetail/customerdetail.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerlistComponent,
    CustomerdetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
