import { Component, OnInit } from '@angular/core';
import { Employee } from '../model/employee';
import { EmployeeService } from '../employee.service';
import { HttpErrorResponse } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { DepartmentService } from '../department.service';
import { Department, DepartmentSelect } from '../model/departments';
import { NotificationService } from '../notification.service';
import { StatusID } from '../model/constants';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  public employees: Employee[];
  public departments: Department[];
  public editEmployee: Employee;
  public deleteEmployee: Employee;
  public restoreEmployee: Employee;

  fileToUpload: File = null;
  public listSelect: DepartmentSelect[];
  selectedStatus: StatusID;
  //selected: Number;

  constructor(private notifyService : NotificationService,
    private employeeService: EmployeeService, 
    private departmentService: DepartmentService) { }

  ngOnInit() {  
    this.selectedStatus = StatusID.Working;
    this.getEmployees();
  }

  dataChanged(value){
    this.selectedStatus = value;
    this.getEmployees();
  }

  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
  }

  public getDepartmentsSelect(): void {
    this.departmentService.getDepartmentSelect().subscribe(
      (response: DepartmentSelect[]) => {
        this.listSelect = response;
      },
      (error: HttpErrorResponse) => {
        console.log(error.message);
      }
    );
 }

  public getEmployees(): void {
    let statusID = this.selectedStatus
    this.employeeService.getEmployees(statusID).subscribe(
      (response: Employee[]) => {
        this.employees = response;
        console.log(this.employees);
      },
      (error: HttpErrorResponse) => {
        console.log(error.message);
      }
    );
    this.getDepartmentsSelect();
  }

  public onAddEmloyee(addForm: NgForm): void {
    document.getElementById('add-employee-form').click();
    this.employeeService.addEmployee(addForm.value).subscribe(
      (response: Employee) => {
        console.log(response);
        this.notifyService.showSuccess("Save successfully!!!", "");
        addForm.reset();
        this.getEmployees();
      },
      (error: HttpErrorResponse) => {
        console.log(error.message);
        this.notifyService.showError("Something wrong!!!", "");
        addForm.reset();
      }
    );
  }

  public onUpdateEmloyee(employeeId: number, employee: Employee): void {
    this.employeeService.updateEmployee(employeeId, employee).subscribe(
      (response: Employee) => {
        console.log(response);
        this.getEmployees();
        this.notifyService.showSuccess("Update successfully!!!", "");
      },
      (error: HttpErrorResponse) => {
        console.log(error.message);
        this.notifyService.showError("Something wrong!!!", "");
      }
    );
  }

  public onRestoreEmloyee(employeeId: number): void {
    this.employeeService.restoreEmployee(employeeId).subscribe(
      (response: void) => {
        console.log(response);
        this.getEmployees();
        this.notifyService.showSuccess("Restore successfully!!!", "");
      },
      (error: HttpErrorResponse) => {
        console.log(error.message);
        this.notifyService.showError("Something wrong!!!", "");
      }
    );
  }

  public onDeleteEmloyee(employeeId: number): void {
    this.employeeService.deleteEmployee(employeeId).subscribe(
      (response: void) => {
        console.log(response);
        this.getEmployees();
        this.notifyService.showSuccess("Delete successfully!!!", "");
      },
      (error: HttpErrorResponse) => {
        console.log(error.message);
        this.notifyService.showError("Something wrong!!!", "");
      }
    );
  }

  public searchEmployees(key: string): void {
    console.log(key);
    const results: Employee[] = [];
    for (const employee of this.employees) {
      if (employee.name.toLowerCase().indexOf(key.toLowerCase()) !== -1
        || employee.email.toLowerCase().indexOf(key.toLowerCase()) !== -1
        || employee.phone.toLowerCase().indexOf(key.toLowerCase()) !== -1
        || employee.jobTitle.toLowerCase().indexOf(key.toLowerCase()) !== -1) {
        results.push(employee);
      }
    }
    this.employees = results;
    if (results.length === 0 || !key) {
      this.getEmployees();
    }
  }

  public onOpenModal(employee: Employee, mode: string): void {
    const container = document.getElementById('main-container');
    const button = document.createElement('button');
    button.type = 'button';
    button.style.display = 'none';
    button.setAttribute('data-toggle', 'modal');
    if (mode === 'add') {
      button.setAttribute('data-target', '#addEmployeeModal');
    }
    if (mode === 'edit') {
      this.editEmployee = employee;
      button.setAttribute('data-target', '#updateEmployeeModal');
    }
    if (mode === 'delete') {
      this.deleteEmployee = employee;
      button.setAttribute('data-target', '#deleteEmployeeModal');
    }
    if (mode === 'restore') {
      this.restoreEmployee = employee;
      button.setAttribute('data-target', '#restoreEmployeeModal');
    }
    container.appendChild(button);
    button.click();
  }
}
