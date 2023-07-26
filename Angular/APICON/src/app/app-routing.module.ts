import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllstudentsComponent } from './allstudents/allstudents.component';
import { StudentbyidComponent } from './studentbyid/studentbyid.component';
import { AddstudentComponent } from './addstudent/addstudent.component';
import { UpdatestudentComponent } from './updatestudent/updatestudent.component';
import { DeletestudentComponent } from './deletestudent/deletestudent.component';

const routes: Routes = [
  { path : "students" , component:AllstudentsComponent  },
  { path : "studentbyid" , component:StudentbyidComponent   },
  { path : "addstudent" , component:AddstudentComponent   },
  { path : "updatestudent" , component:UpdatestudentComponent   },
  { path: "deletestudent", component:DeletestudentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
