import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Department, DepartmentSelect } from './model/departments';

@Injectable({ providedIn: 'root' })
export class DepartmentService {
  private apiServerUrl = `${environment.apiBaseUrl}/api/Department`;

  constructor(private http: HttpClient) { }

  public getDepartments(): Observable<Department[]> {
    return this.http.get<Department[]>(`${this.apiServerUrl}/SearchList`);
  };

  public getDepartmentSelect(): Observable<DepartmentSelect[]> {
    return this.http.get<DepartmentSelect[]>(`${this.apiServerUrl}/SearchListSelect`);
  };

  public addDepartment(department: Department): Observable<Department> {
    return this.http.post<Department>(`${this.apiServerUrl}/Create`, department);
  };

  public updateDepartment(departmentID: number, department: Department): Observable<Department> {
    return this.http.put<Department>(`${this.apiServerUrl}/Update/${departmentID}`, department);
  }

  public deleteDepartment(departmentID: number): Observable<void> {
    return this.http.delete<void>(`${this.apiServerUrl}/Delete/${departmentID}`);
  };
}
