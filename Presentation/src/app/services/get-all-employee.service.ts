import { Injectable } from "@angular/core";
import {HttpClient, HttpHeaders} from "@angular/common/http"
import { Employee } from "../models/employee";
import {Observable} from "rxjs";
@Injectable({
    providedIn: 'root'
})
export class GetAllEmployeeService{
    _url = 'https://localhost:7083/API/Employee/GetDistinct'
    constructor(
        private http:HttpClient
    ){     
    }
    getEmployee():Observable<Employee[]>{
        return this.http.get<Employee[]>(this._url)
    }
}