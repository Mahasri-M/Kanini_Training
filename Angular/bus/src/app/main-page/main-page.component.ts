import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent {
  boardingPoint: string = '';
  destination: string = '';
  selectedDate: any;
  availableBuses: string[] = [];
  constructor(private router: Router) { }
  
  searchBuses() {
    const availableBuses = this.getAvailableBuses();
    if(availableBuses.length>0){
    this.router.navigate(['/busselection'], { queryParams: { buses: JSON.stringify(availableBuses) } });
    }else{
      alert('No buses available for this route');
    }
  }

  private getAvailableBuses(): string[] {
    const busDetails = new Map<string, string[]>();

    busDetails.set('chennai to coimbatore', ['Balaji Tours and Travels', 'National travels', 'Krish Travels', 'Intrcity']);
    busDetails.set('coimbatore to chennai', ['Intrcity', 'Vignesh TAT']);
    busDetails.set('chennai to bangalore', ['No1 Air', 'JB Connect']);
    busDetails.set('bangalore to chennai', ['Jg travels', 'National travels', 'KRS travels']);
    busDetails.set('chennai to pollachi', ['MJT', 'KRS']);
    busDetails.set('erode to chennai', ['Vijay']);
    busDetails.set('chennai to erode',['SBLT'] );
  

    const route = `${this.boardingPoint} to ${this.destination}`;
    return busDetails.get(route) || [];
  }
}