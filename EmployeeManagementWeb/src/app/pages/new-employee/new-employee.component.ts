import { Component, OnInit } from '@angular/core';
import { Employee, EmployeeService } from '../../services/employee.service';
import { Role, RoleService } from '../../services/role.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-employee',
  templateUrl: './new-employee.component.html',
  styleUrls: ['./new-employee.component.css']
})
export class NewEmployeeComponent implements OnInit {
  roles: Role[] = [];
  directors: Employee[] = [];
  selectedDirector?: string = undefined;
  directorRoleId: string = '';
  firstName: string = '';
  lastName: string = '';
  constructor(private employeeService: EmployeeService, private roleService: RoleService,
    private router: Router) { }

  addUser(): void {
    var roles = this.roles.filter(r => r.inRole).map(r => r.id);

    if (roles.length === 0) {
      alert('You must select at least one role.');
      return;
    }

    if (this.firstName === '' || this.lastName === '') {
      alert('You must enter a first and last name.');
      return;
    }
    console.log(this.selectedDirector);
    if (!this.selectedDirector && !roles.includes(this.directorRoleId)) {
      alert('You must select a director.');
      return;
    }

    this.employeeService.addEmployee({
      firstName: this.firstName,
      lastName: this.lastName,
      managerId: this.selectedDirector,
      roles: roles
    }).subscribe(result => {
      alert('Employee added successfully.');
      this.router.navigate(['/']);
    }, error => console.error(error));
  }

  selectDirector(directorId?: string): void {
    this.selectedDirector = directorId;
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
    this.roleService.getRoles().subscribe(result => {
      this.roles = result;
      this.directorRoleId = this.roles.find(r => r.name === 'Director')?.id ?? '';
      this.employeeService.getDirectors().subscribe(result => {
        this.directors = result;
        if (this.directors.length == 0)
          this.roles.find(r => r.id === this.directorRoleId)!.inRole = true;
        else
          this.selectDirector(this.directors[0].id);
      });
      
    }, error => console.error(error));
  }
}
