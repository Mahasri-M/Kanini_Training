import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-adminpage',
  templateUrl: './adminpage.component.html',
  styleUrls: ['./adminpage.component.css']
})
export class AdminpageComponent {
  public users: any;
  public isUpdateFormOpen: boolean = false;
  public isUpdateFormOpenbook: boolean = false;
  public isUpdateFormOpenbus:boolean =false;
  public isAddFormOpen:boolean =false;
  public isAddbookFormOpen:boolean =false;
  public isAddbusFormOpen:boolean=false;
  public student: any = {};
  public bookings:any ={};
  public book:any={};
  public buses:any={};
  public bus:any={};
  public AddStudentForm! : FormGroup;
  public AddBookingForm!: FormGroup;
  public AddBusForm!:FormGroup;
  constructor(private service: AuthService,private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    this.getStudents();
    this.getBookings();
    this.getBuses();
    this.addUser();
    this.addBooking();
    this.addBus();
  }

  private getStudents(): void {
    this.service.getAllUsers().subscribe(result => {
      this.users = result;
      console.log(this.users);
    });
  }

  private getBookings(): void{
    this.service.getAllBookings().subscribe(result =>{
      this.bookings = result;
      console.log(this.bookings);
    })
  }

  private getBuses():void{
    this.service.getAllBuses().subscribe(result =>{
      this.buses=result;
      console.log(this.buses);
    })
  }
// adduser
  public openAdduser(user: any): void {
    this.isAddFormOpen = true;
    
    this.student = { ...user };
  }
  public openAddusers(): void {
    this.isAddFormOpen = true;
    this.student = {}; // Initialize with empty values
  }

  private addUser() : void
  {
    this.AddStudentForm = this.formBuilder.group({
      // userId:[],
      name:[],
      email:[],
      mobile:[],
      pwd:[]
    });
  }

  public AddNewStudent():void
  {
    this.service.AddNewUser (this.AddStudentForm.value)
    .subscribe(result =>
      {
      alert(" User Added ");
      });
  }

  // bookingadd
  public openAddbook(booking: any): void {
    this.isAddbookFormOpen = true;
    
    this.book = { ...booking };
  }
  public openAddbooks(): void {
    this.isAddbookFormOpen = true;
    this.book = {}; 
  }

  private addBooking() : void
  {
    this.AddBookingForm = this.formBuilder.group({
    
      passenger_name:[],
      age:[],
      gender:[],
      email:[],
      mobile:[]
    });
  }
  
  public AddNewBooking():void
  {
    this.service.submitPassengerDetails (this.AddBookingForm.value)
    .subscribe(result =>
      {
      alert(" Booking Added ");
      });
  }

  //addbus

  public openAddbus(bus: any): void {
    this.isAddbusFormOpen = true;
    
    this.bus = { ...bus };
  }
  public openAddbuses(): void {
    this.isAddbusFormOpen = true;
    this.bus = {}; 
  }

  private addBus() : void
  {
    this.AddBusForm = this.formBuilder.group({
    
      busname:[],
      price:[],
      type:[],
      timing:[],
      boarding:[],
      destination:[]
    });
  }
  
  public AddNewBus():void
  {
    this.service.AddNewBus (this.AddBusForm.value)
    .subscribe(result =>
      {
      alert(" Booking Added ");
      });
  }

  
  // deleteuser
  public deleteUser(userId: number): void {
    this.users = this.users.filter((user: any) => user.userId !== userId);

    this.service.DeleteUser(userId).subscribe(
      () => console.log(`User with ID ${userId} deleted successfully from the database.`),
      (error: any) => console.error('An error occurred while deleting the user:', error)
    );
  }
//deletebooking
  public deleteBooking(bookingId: number): void {
   
    this.bookings = this.bookings.filter((booking: any) => booking.bookingId !== bookingId);

    this.service.DeleteBooking(bookingId).subscribe(
      () => console.log(`Booking with ID ${bookingId} deleted successfully from the database.`),
      (error: any) => console.error('An error occurred while deleting the booking:', error)
    );
  }
//deletebus
public deleteBus(busId: number): void {
   
  this.buses = this.buses.filter((bus: any) => bus.busId !== busId);

  this.service.DeleteBus(busId).subscribe(
    () => console.log(`Bus with ID ${busId} deleted successfully from the database.`),
    (error: any) => console.error('An error occurred while deleting the booking:', error)
  );
}

  //update user 
  id!:number;
  public UpdateStudentById(){
    return this.service.UpdateUser(this.id ,this.student)
    .subscribe( result =>
      {
        alert(" Student Updated ");
      }
      );
  
}

public openUpdateForm(user: any): void {
  this.isUpdateFormOpen = true;
  
  this.student = { ...user };
}

//updatebook
  public UpdateBookingById(){
    return this.service.Updatebooking(this.id ,this.book)
    .subscribe( result =>
      {
        alert(" Booking Updated ");
      }
      );
  
}

public openUpdateFormbook(booking: any): void {
  this.isUpdateFormOpenbook = true;
  
  this.book = { ...booking };
}

//updatebus
public UpdateBusById(){
  return this.service.Updatebus(this.id ,this.bus)
  .subscribe( result =>
    {
      alert(" Bus Updated ");
    }
    );

}

public openUpdateFormbus(bus: any): void {
this.isUpdateFormOpenbus = true;

this.bus = { ...bus };
}
}
