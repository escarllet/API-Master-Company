import { Component } from '@angular/core';
import { GetAllEmployeeService } from 'src/app/services/get-all-employee.service';
import { Employee } from 'src/app/models/employee';
@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent {

  constructor(
    private getallemployeeservice:GetAllEmployeeService, 
    
  ){
    this.getallemployeeservice.getEmployee().subscribe(resp=>(
      console.log(resp)
      
    ))
  }
}
