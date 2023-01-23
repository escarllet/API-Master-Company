import { Injectable } from "@angular/core";
import{HttpClient, HttpHeaders} from "@angular/common/http"
@Injectable({
    providedIn: 'root'
})
export class GetAllEmployeeService{
    _url = 'https://localhost:7083/API/Employee/GetAll'
    constructor(
        private http:HttpClient
    ){     
    }
    getAllEmployee(){
     let header = new HttpHeaders()
     .set('Type-content','aplication/json')  

        return this.http.get(this._url, {
            headers:header
        });

    }
}