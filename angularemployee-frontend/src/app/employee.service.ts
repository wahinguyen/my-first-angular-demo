import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../app/model/employee';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class EmployeeService {
  private apiServerUrl = `${environment.apiBaseUrl}/api/Employee`;

  constructor(private http: HttpClient) { }


  public getEmployees(statusID: number): Observable<Employee[]> {

    return this.http.get<Employee[]>(`${this.apiServerUrl}/SearchList`, {
      params: new HttpParams().set("statusID", `${statusID}`)
    });
  }

  public addEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(`${this.apiServerUrl}/Create`, employee);
  }

  public updateEmployee(employeeId: number, employee: Employee): Observable<Employee> {
    return this.http.put<Employee>(`${this.apiServerUrl}/Update/${employeeId}`, employee);
  }

  public restoreEmployee(employeeId: number): Observable<void> {
    return this.http.put<void>(`${this.apiServerUrl}/Restore/${employeeId}`, {});
  }

  public deleteEmployee(employeeId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiServerUrl}/Delete/${employeeId}`);
  }
}
