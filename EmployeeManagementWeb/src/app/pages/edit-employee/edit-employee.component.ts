import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Employee, EmployeeService, EditEmployee } from 'src/app/services/employee.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.scss']
})
export class EditEmployeeComponent implements OnInit {
  private id: string = '';
  public employee: Employee = {} as Employee;
  constructor(private activatedRoute: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService) { }

  saveEmployee(): void {

    let newEmploee: EditEmployee = {
      firstName: this.employee.firstName,
      lastName: this.employee.lastName
    };
    
    this.employeeService.updateEmployee(this.id, newEmploee).subscribe(result => {
      alert('Employee updated successfully.');
      this.router.navigate(['/']);
    }, error => console.error(error));
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((param : Params) => {
            this.id = param['id'];

            this.employeeService.getEmployee(this.id).subscribe(result => {
              this.employee = result;
            });
        });
  }
}
