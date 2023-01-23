import { Component } from '@angular/core';
import { GetAllEmployeeService } from 'src/app/services/get-all-employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent {

  constructor(
    private getallemployeeservice:GetAllEmployeeService 
  ){
    this.getallemployeeservice.getAllEmployee().subscribe(resp=>(
      console.log(resp)
    ))
  }
}
