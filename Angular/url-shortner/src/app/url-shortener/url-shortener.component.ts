import { Component } from '@angular/core';
import * as shortid from 'shortid';

@Component({
  selector: 'app-url-shortener',
  templateUrl: './url-shortener.component.html',
  styleUrls: ['./url-shortener.component.css']
})
export class UrlShortenerComponent {
  urlInput: string = '';
  shortenedUrl: string = '';

  shortenUrl() {
    // Generate a unique shortened URL using shortid
    this.shortenedUrl = 'https://short.url/' + shortid.generate();
  }
}
