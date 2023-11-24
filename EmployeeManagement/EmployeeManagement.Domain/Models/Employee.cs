namespace EmployeeManagement.Domain.Models;

public class Employee
{
    public Guid Id { get; set; }
    public string EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Guid? ManagerId { get; set; }

    public Employee? Manager { get; set; }


    public ICollection<Role> Roles { get; set; }
}