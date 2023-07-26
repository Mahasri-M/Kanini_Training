import { Component } from '@angular/core';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-studentbyid',
  templateUrl: './studentbyid.component.html',
  styleUrls: ['./studentbyid.component.css']
})
export class StudentbyidComponent {

  public student: any;
  id!:number;

  constructor(private studentService: StudentService,
    ) { }

  ngOnInit(): void {
  }
  
  public GetStudentById(){
      return this.studentService.getStudentsById(this.id)
      .subscribe(result => this.student = result );
    
  }

}
