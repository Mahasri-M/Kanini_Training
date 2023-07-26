import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import * as pdfMake from 'pdfmake/build/pdfmake';
import * as pdfFonts from 'pdfmake/build/vfs_fonts';
import { TDocumentDefinitions, Content, TableCell } from 'pdfmake/interfaces';
import { AuthService } from '../services/auth.service';
import { SMTPClient } from 'smtpjs';
import * as tls from 'tls';
import * as fs from 'fs';
import * as net from 'net';
import { HttpClient } from '@angular/common/http';


(pdfMake as any).vfs = pdfFonts.pdfMake.vfs;

@Component({
  selector: 'app-pdfpage',
  templateUrl: './pdfpage.component.html',
  styleUrls: ['./pdfpage.component.css']
})
export class PdfpageComponent implements OnInit {

  public pdfview! :FormGroup;
  bookingResult: string='';
  selectedButton: string = '';
  selectedSeat: string = '';
  vehitiming: string = '';
  totalPrice: number = 0;
  bustype:string='';
  passengerDetails: any = {
    name:'',
    age:'',
    gender:'',
    mobile:'',
    email:'',
    seatNumber:''
  }; 
  bus:any;

  constructor(private route: ActivatedRoute, private formBuilder:FormBuilder, private authService:AuthService,private http:HttpClient) { }

  ngOnInit():void {
    this.pdf();
    this.route.queryParams.subscribe(params => {
      this.selectedButton = params['bus'];
      this.selectedSeat = params['seat'];
      this.vehitiming = params['timing'];
      this.totalPrice = params['price']; 
      this.bustype = params['type'];
    });
  }

  private pdf():void {
    this.pdfview = this.formBuilder.group({
      passenger_name: [],
      age: [],
      gender: [],
      email: [],
      mobile: []
    });
  }

  public submitPassengerDetails():void {
    this.authService.submitPassengerDetails(this.pdfview.value).subscribe(result => {
      this.bookingResult = "Booked successfully. Now you can view or download your ticket";
    });
  }

  public generatePdf(openMode: 'open' | 'download'):void {
    const documentDefinition:TDocumentDefinitions = {
      content: [
        { text: 'Ticket Information', style: 'mainheader' },
        { text: 'Your ticket confirmed.', style: 'content' },
        {
          table: {
            widths: [100, '*'],
            body:[
              [{ text: 'Ticket Details',
                 style: 'subheader',
                 colSpan: 2,
                 fillColor: '#c76e7a',
                 background: '#c76e7a',
                 alignment: 'center',
                 border: [true, true, true, true], 
                 margin: [10, 10],
                 bold: true,
                 fontSize: 14,
                 padding: [5, 5]
              }, {}],
              [{ text: 'Bus Name:', style: 'busNameLabelStyle' }, { text: this.selectedButton, style: 'busNameValueStyle' }],
              [{ text: 'Seat:', style: 'busNameValueStyle' }, { text: this.selectedSeat, style: 'busNameLabelStyle' }],
              [{ text: 'Timing:', style: 'busNameLabelStyle' }, { text: this.vehitiming, style: 'busNameValueStyle' }],
              [{ text: 'Type:', style: 'busNameValueStyle' }, { text: this.bustype, style: 'busNameLabelStyle' }],
              [{ text: 'Price:', style: 'busNameLabelStyle' }, { text: this.totalPrice, style: 'busNameValueStyle' }]
            ]
          },
          layout: 'lightHorizontalLines'
        },
        { text: 'Passenger Details', style: 'mainheader' },
        { text: 'Please review the passenger details below:', style: 'content' },
        {
          table: {
            widths: ['*', '*', '*'],
            body:[
              [{ text: 'Name', style: 'tableHeader' }, { text: 'Age', style: 'tableHeader' }, { text: 'Gender', style: 'tableHeader' }],
              [this.passengerDetails.name, this.passengerDetails.age, this.passengerDetails.gender]
            ]
          },
          layout: 'lightHorizontalLines'
        }
      ],
      styles: {
        mainheader: {
          fontSize: 18,
          bold: true,
          margin: [0, 20, 0, 10]
        },
        subheader: {
          fontSize: 16,
          bold: true,
          margin: [0, 5, 0, 5]
        },
        content: {
          fontSize: 14,
          margin: [0, 0, 0, 10]
        },
        busNameLabelStyle: {
          bold: true,
          fontSize: 12,
          margin: [0, 2, 0, 2],
        },
        busNameValueStyle: {
          fontSize: 12,
          margin: [0, 2, 0, 2],
        },
        tableHeader: {
          bold: true,
          fontSize: 12,
          color: 'black',
          fillColor: '#c76e7a',
          background: '#c76e7a',
          alignment: 'center',
          margin: [10, 10],
        }
        
        
      }
    };
    if (openMode === 'open') {
      pdfMake.createPdf(documentDefinition).open();
    } else {
      pdfMake.createPdf(documentDefinition).download();
    }
  }

  

// sendEmail(): void {
//   const emailData = {
//     recipientEmail: 'mahatamilnadu123@gmail.com',
//     subject: 'Ticket Information',
//     emailContent: 'This is the email content.',
//   };

//   this.http.post('https://localhost:44382/api/Booking/sendEmail', emailData).subscribe(
//     (response) => {
//       console.log('Email sent successfully', response);
//     },
//     (error) => {
//       console.error('Failed to send email', error);
//     }
//   );
// }

// sendEmail(): void {
//   if (this.pdfview.valid) {
//     this.authService.submitPassengerDetails(this.pdfview.value).subscribe(result => {
//       this.bookingResult = "Booked successfully. Now you can view or download your ticket";
//     });
//     const formData = this.pdfview.value;
//     const mailtoLink = `mailto:mahasrim5555@gmail.com?subject=Booking Details&body=Name: ${formData.passenger_name}%0D%0AAge: ${formData.age}%0D%0AGender: ${formData.gender}%0D%0AMobile Number: ${formData.mobile}%0D%0AEmail: ${formData.email}`;
//     window.location.href = mailtoLink;
//   }
// }
sendEmail(): void {
  if (this.pdfview.valid) {
    this.authService.submitPassengerDetails(this.pdfview.value).subscribe(result => {
      this.bookingResult = "Booked successfully. Now you can view or download your ticket";
      const formData = this.pdfview.value;
      const mailtoLink = `mailto:${formData.email}?subject=Booking Details&body=Name: ${formData.passenger_name}%0D%0AAge: ${formData.age}%0D%0AGender: ${formData.gender}%0D%0AMobile Number: ${formData.mobile}%0D%0AEmail: ${formData.email}`;
      window.location.href = mailtoLink;
    });
  }
}
}
