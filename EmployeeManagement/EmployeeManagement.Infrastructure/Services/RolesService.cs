using EmployeeManagement.Domain.Contracts;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Infrastructure.Context;

namespace EmployeeManagement.Infrastructure.Services;

public class RolesService : IRolesService
{
    private readonly EmployeeContext _context;

    public RolesService(EmployeeContext context)
    {
        _context = context;
    }

    public IList<Role> GetAllRoles()
    {
        return _context.Roles.ToList();
    }
}