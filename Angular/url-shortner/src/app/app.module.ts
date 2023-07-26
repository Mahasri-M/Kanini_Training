import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';


import { AppComponent } from './app.component';
import { ShortenedUrlDisplayComponent } from './shortened-url-display/shortened-url-display.component';
import { UrlShortenerComponent } from './url-shortener/url-shortener.component';

@NgModule({
  declarations: [
    AppComponent,
    ShortenedUrlDisplayComponent,
    UrlShortenerComponent
  ],
  imports: [
    BrowserModule,FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
