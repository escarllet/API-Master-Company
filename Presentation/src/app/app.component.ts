import { Component } from '@angular/core';
import { GetAllEmployeeService } from './services/get-all-employee.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers:[GetAllEmployeeService]
})
export class AppComponent {
  title = 'Presentation';
  constructor(private dataSvc:GetAllEmployeeService){

  }
  ngOnInit(){
    this.dataSvc.getAllEmployee().subscribe(res=>{
      console.log('Res',res);
    });
  }
}
