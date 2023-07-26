import { Component } from '@angular/core';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-deletestudent',
  templateUrl: './deletestudent.component.html',
  styleUrls: ['./deletestudent.component.css']
})
export class DeletestudentComponent {

  public student: any;
  id!:number;

  constructor(private studentService: StudentService,
    ) { }

  ngOnInit(): void {
  }
  
  public DeleteStudentById(){
      return this.studentService.DeleteStudentById(this.id)
      .subscribe(result => {
        alert("Deleted");
      } );
    
  }

}


