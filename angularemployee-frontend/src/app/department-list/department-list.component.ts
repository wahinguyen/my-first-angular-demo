import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DepartmentService } from 'src/app/department.service';
import { Department } from 'src/app/model/departments';
import { NotificationService } from '../notification.service';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {
  public departments: Department[];
  public editDepartment: Department;
  public deleteDepartment: Department;

  constructor(private notifyService : NotificationService, private departmentService: DepartmentService) { }

  ngOnInit(): void {
    this.getDepartments();
  }

  public getDepartments(): void {
    this.departmentService.getDepartments().subscribe(
      (response: Department[]) => {
        this.departments = response;
        console.log(this.departments);
      },
      (error: HttpErrorResponse) => {
        console.log(error.message);
      }
    );
  }

  public onAddDepartment(addForm: NgForm): void {
    document.getElementById('add-department-form').click();
    this.departmentService.addDepartment(addForm.value).subscribe(
      (response: Department) => {
        console.log(response),
        this.getDepartments();
        this.notifyService.showSuccess("Save successfully!!!", "");
        addForm.reset();
      },
      (error: HttpErrorResponse) => {
        this.notifyService.showError("Something wrong!!!", "");
        console.log(error.message);
        addForm.reset();
      }
    );
  }

  public onUpdateDepartment(departmentID: number, department: Department): void {
    this.departmentService.updateDepartment(departmentID, department).subscribe(
      (response: Department) => {
        console.log(response);
        this.getDepartments();
        this.notifyService.showSuccess("Update successfully!!!", "");
      },
      (error: HttpErrorResponse) => {
        this.notifyService.showError("Something wrong!!!", "");
        console.log(error.message);
      }
    );
  }

  public onDeleteDepartment(departmentID: number): void {
    console.log(departmentID);
    this.departmentService.deleteDepartment(departmentID).subscribe(
      (response: void) => {
        console.log(response);
        this.getDepartments();
        this.notifyService.showSuccess("Delete successfully!!!", "");
      },
      (error: HttpErrorResponse) => {
        this.notifyService.showWarning("This department is using!!!", "");
        console.log(error.message);
      }
    );
  }

  public searchDepartments(key: string): void {
    console.log(key);
    const results: Department[] = [];
    for (const department of this.departments) {
      if (department.departmentName.toLowerCase().indexOf(key.toLowerCase()) !== -1
        || department.description.toLowerCase().indexOf(key.toLowerCase()) !== -1) {
        results.push(department);
      }
    }
    this.departments = results;
    if (results.length === 0 || !key) {
      this.getDepartments();
    }
  }

  public onOpenModal(department: Department, mode: string): void {
    const container = document.getElementById('main-container');
    const button = document.createElement('button');
    button.type = 'button';
    button.style.display = 'none';
    button.setAttribute('data-toggle', 'modal');
    if (mode === 'add') {
      button.setAttribute('data-target', '#addDepartmentModal');
    }
    if (mode === 'edit') {
      this.editDepartment = department;
      button.setAttribute('data-target', '#updateDepartmentModal');
    }
    if (mode === 'delete') {
      this.deleteDepartment = department;
      button.setAttribute('data-target', '#deleteDepartmentModal');
    }
    container.appendChild(button);
    button.click();
  }

}
