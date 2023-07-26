 
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import * as pdfMake from 'pdfmake/build/pdfmake';
import * as pdfFonts from 'pdfmake/build/vfs_fonts';


(pdfMake as any).vfs = pdfFonts.pdfMake.vfs;

@Component({
  selector: 'app-busselection',
  templateUrl: './busselection.component.html',
  styleUrls: ['./busselection.component.css']
})
export class BusselectionComponent implements OnInit {
  bus: string = '';
  availableBuses: string[] = [
    'National travels',
    'Krish Travels',
    'Balaji Tours and Travels',
    'Vignesh TAT',
    'KRS',
    'MJT',
    'SBLT',
    'Vijay',
    'No1 Air',
    'JB Connect',
    'Intrcity'
  ];
  selectedButton: string = '';
  selectedSeat: string = '';
  totalPrice: number = 0;
  vehitiming: string = '';
  timing: string = '';
  type:string='';
  bustype:string='';
  filteredBuses: string[] = [];
  filterMinPrice: number = 0;
  filterMaxPrice: number = 0;


  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      if (params['buses']) {
        this.availableBuses = JSON.parse(params['buses']);
      }
    });
  }

  showPassengerForm(button: string, seat: string, timing: string,type:string) {
    this.selectedButton = button;
    this.selectedSeat = seat;
    this.calculateTiming();
    this.calculatePrice();
    this.calculateType();
  }

  getPrice(bus: string) {
    if (bus === 'JB Connect') {
      return 800;
    } else if (bus === 'National travels') {
      return 999;
    } else if (bus === 'Krish Travels') {
      return 1500;
    } else if (bus === 'KRS') {
      return 999;
    } else if (bus === 'MJT') {
      return 1500;
    } else if (bus === 'SBLT') {
      return 1300;
    } else if (bus === 'Vignesh TAT') {
      return 1400;
    } else if (bus === 'Balaji Tours and Travels') {
      return 1200;
    } else if (bus === 'Vijay') {
      return 1300;
    }else if (bus === 'No1 Air') {
      return 990;
    }else if (bus === 'Intrcity') {
      return 1600;
    }else {
      return 0;
    }
  }

  getTiming(bus: string) {
    if (bus === 'JB Connect') {
      return '10PM-8PM';
    } else if (bus === 'National travels') {
      return '9PM-8AM';
    } else if (bus === 'Krish Travels') {
      return '10PM-6AM';
    } else if (bus === 'KRS') {
      return '9PM-7AM';
    } else if (bus === 'MJT') {
      return '10PM-8AM';
    } else if (bus === 'SBLT') {
      return '10PM-6AM';
    } else if (bus === 'Vignesh TAT') {
      return '10PM-8AM';
    } else if (bus === 'Balaji Tours and Travels') {
      return '8PM-7AM';
    } else if (bus === 'Vijay') {
      return '10PM-6AM';
    }else if (bus === 'No1 Air') {
      return '10PM-6AM';
    }else if (bus === 'Intrcity') {
      return '10PM-6AM';
    }else {
      return '';
    }
  }

  getType(bus: string) {
    if (bus === 'JB Connect') {
      return 'Non AC';
    } else if (bus === 'National travels') {
      return 'Non AC';
    } else if (bus === 'Krish Travels') {
      return 'AC';
    } else if (bus === 'KRS') {
      return 'Non Ac';
    } else if (bus === 'MJT') {
      return 'AC';
    } else if (bus === 'SBLT') {
      return 'AC';
    } else if (bus === 'Vignesh TAT') {
      return 'AC';
    } else if (bus === 'Balaji Tours and Travels') {
      return 'Non AC';
    } else if (bus === 'Vijay') {
      return 'AC';
    }else if (bus === 'No1 Air') {
      return 'Non AC';
    }else if (bus === 'Intrcity') {
      return 'AC';
    }else {
      return '';
    }
  }



  calculatePrice() {
    const price = this.getPrice(this.selectedButton);
    this.totalPrice = price;
  }

  calculateTiming() {
    const timing = this.getTiming(this.selectedButton);
    this.vehitiming = timing;
  }
  calculateType(){
    const type = this.getType(this.selectedButton);
    this.bustype=type;
  }
  navigateToPdfPage() {
    const queryParams = {
      bus: this.selectedButton,
      seat: this.selectedSeat,
      price: this.totalPrice,
      timing: this.vehitiming,
      type: this.bustype
    };
    this.router.navigate(['/pdfpage'], { queryParams });
  }

  // filterBusesByPrice() {
  //   this.filteredBuses = this.availableBuses.filter((bus) => {
  //     const price = this.getPrice(bus);
  //     return price >= this.filterMinPrice && price <= this.filterMaxPrice;
  //   });
  // }

  
}

