using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Domain.Contracts;

public interface IEmployeeService
{
    IList<Employee> GetEmployeesByManager(Guid managerId);
    IList<Employee> GetEmployeesByRole(Guid roleId);
    IList<Employee> GetDirectors();
    IList<Employee> GetAllEmployees();

    Task<Employee> GetEmployeeById(Guid id);
    Task AddEmployee(string firstName, string lastName, Guid? managerId, IList<Guid> roleIds);
    Task UpdateEmployee(Guid id, string firstName, string lastName);
}