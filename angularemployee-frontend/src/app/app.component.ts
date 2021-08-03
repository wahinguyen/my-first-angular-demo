import { Component, OnInit } from '@angular/core';
import { Employee } from '../app/model/employee';
import { EmployeeService } from './employee.service';
import { HttpErrorResponse } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { NotificationService } from './notification.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public employees: Employee[];
  public editEmployee: Employee;
  public deleteEmployee: Employee;
  fileToUpload: File = null;

  constructor( private employeeService: EmployeeService) { }

  ngOnInit() {
  }



}
