import { Component ,EventEmitter,Input,Output} from '@angular/core';
import { Customer } from '../customer';

@Component({
  selector: 'app-customerdetail',
  templateUrl: './customerdetail.component.html',
  styleUrls: ['./customerdetail.component.css']
})
export class CustomerdetailComponent {
  @Input() customer:Customer = new Customer();
  @Output() customerChange:EventEmitter<Customer> =new EventEmitter<Customer>(); 
    
  constructor() { }
 
  ngOnInit() {
  }
 
  update() {
    this.customerChange.emit(this.customer);
  }
}
