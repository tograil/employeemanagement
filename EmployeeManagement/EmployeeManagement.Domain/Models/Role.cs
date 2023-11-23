namespace EmployeeManagement.Domain.Models;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<Employee> Employees { get; set; }
}