using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Domain.Contracts;

public interface IRolesService
{
    IList<Role> GetAllRoles();
}