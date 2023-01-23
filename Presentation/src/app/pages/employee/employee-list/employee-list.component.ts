import { Component, OnInit } from '@angular/core';
import { GetAllEmployeeService } from 'src/app/services/get-all-employee.service';
import { Employee } from 'src/app/models/employee';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})

export class EmployeeListComponent implements OnInit{
  employee:Employee[] =[];
  constructor(
    private getallemployeeservice:GetAllEmployeeService
  ){
    
  }
  ngOnInit(): void {
    this.getallemployeeservice.getEmployee().subscribe(employee=>(
      this.employee = employee,
      console.log(employee)
      
    ))
  }
  
  
  
}
