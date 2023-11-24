import { Component, OnInit } from '@angular/core';
import { Employee, EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  directors: Employee[] = [];
  employees: Employee[] = [];
  selectedDirector?: string = '';
  constructor(private employeeService: EmployeeService) {

  }

  selectDirector(directorId?: string): void {
    this.selectedDirector = directorId;

    if (directorId === undefined) {
      this.employees = [];
      return;
    }

    this.employeeService.getEmployees(directorId).subscribe(result => {
      this.employees = result;

      console.log(this.employees);
    }, error => console.error(error));
  }

  get currentDirector(): string {
    if (this.selectedDirector === undefined) {
      return 'No director selected';
    }

    var director = this.directors.find(d => d.id === this.selectedDirector);
    if (director === undefined) {
      return 'No director selected';
    }

    return `${director.firstName} ${director.lastName}`;
  }

  ngOnInit(): void {
    this.employeeService.getDirectors().subscribe(result => {
      this.directors = result;
      if (this.directors.length > 0)
        this.selectDirector(this.directors[0].id);
    }, error => console.log(error));
  }
}
