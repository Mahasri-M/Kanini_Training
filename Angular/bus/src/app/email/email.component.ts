import { Component } from '@angular/core';

@Component({
  selector: 'app-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.css']
})
export class EmailComponent {
  formDetails: any = {
    recipient: 'mahasrim5555@gmail.com',
    subject: 'Email with PDF Attachment',
    body: 'Please find attached PDF file.'
  };
  generateMailtoLink(): string {
    const { recipient, subject, body } = this.formDetails;
    const mailtoLink = `mailto:${recipient}?subject=${encodeURIComponent(subject)}&body=${encodeURIComponent(body)}`;
    return mailtoLink;
  }
}
