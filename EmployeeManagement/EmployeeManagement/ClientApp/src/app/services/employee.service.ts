import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  addEmployee(employee: NewEmployee) : Observable<any> {
    return this.http.post(this.baseUrl + 'api/employee', employee);
  }

  constructor(private http: HttpClient,
     @Inject('BASE_URL')private baseUrl: string) { }

  getDirectors(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseUrl + 'api/employee/directors');
  }

  getEmployees(managerId: string): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseUrl + `api/employee/manager/${managerId}`);
  }
}

export interface Employee {
  id: string;
  firstName: string;
  lastName: string;
  managerId?: string;
}

export interface NewEmployee {
  firstName: string;
  lastName: string;
  managerId?: string;
  roles: string[];
}
