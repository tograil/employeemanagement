namespace EmployeeManagement.Api.Models;

public class NewEmployeeModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid? ManagerId { get; set; }
    public IList<Guid> Roles { get; set; }
}