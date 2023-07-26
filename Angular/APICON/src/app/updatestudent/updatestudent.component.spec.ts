import { Component } from '@angular/core';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-updatestudent',
  templateUrl: './updatestudent.component.html',
  styleUrls: ['./updatestudent.component.css']
})
export class UpdatestudentComponent {

  student:any = {name :'', city : '', pin : ''};
  
  id!:number;

  constructor(private studentService: StudentService,
    ) { }

  ngOnInit(): void {
  }

  public UpdateStudentById(){
      return this.studentService.UpdateStudent(this.id ,this.student)
      .subscribe( result =>
        {
          alert(" Student Updated ");
        }
        );
    
  }

}
