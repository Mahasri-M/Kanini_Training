import { Component, Input } from '@angular/core';

@Component({
  selector: 'shortened-url-display',
  templateUrl: './shortened-url-display.component.html',
  styleUrls: ['./shortened-url-display.component.css']
})


export class ShortenedUrlDisplayComponent {
  @Input() shortenedUrl!: string;

  copyToClipboard() {
    // Implement the logic to copy the shortened URL to the clipboard here
    // You can use JavaScript Clipboard API or a library like ngx-clipboard
  }
}
