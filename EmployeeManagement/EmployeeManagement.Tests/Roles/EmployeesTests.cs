using EmployeeManagement.Domain.Contracts;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Infrastructure.Services;
using EmployeeManagement.Tests.Utils;

namespace EmployeeManagement.Tests.Roles;

[TestFixture]
public class EmployeesTests
{
    private IEmployeeService _employeeService = null!;
    private Employee _director = null!;
    private Employee _accounting = null!;
    private Employee _sales = null!;

    [SetUp]
    public void Setup()
    {
        var context = DatabaseUtils.GetInMemoryDatabaseContext();
        _employeeService = new EmployeeService(context);

        var roles = context.Roles.ToList();

        var directorRole = roles.First(x => x.Name == "Director");
        var accountingRole = roles.First(x => x.Name == "Accounting");
        var salesRole = roles.First(x => x.Name == "Sales");

        _director = context.Employees.Add(new Employee
        {
            Id = Guid.NewGuid(),
            EmployeeId = Domain.Utils.EmployeeUtils.GenerateEmployeeId(),
            FirstName = "John",
            LastName = "Doe",
            ManagerId = null,
            Roles = new List<Role>
            {
                directorRole
            }
        }).Entity;

        _accounting = context.Employees.Add(new Employee
        {
            Id = Guid.NewGuid(),
            EmployeeId = Domain.Utils.EmployeeUtils.GenerateEmployeeId(),
            FirstName = "Jane",
            LastName = "Doe",
            ManagerId = _director.Id,
            Roles = new List<Role>
            {
                accountingRole
            }
        }).Entity;

        _sales = context.Employees.Add(new Employee
        {
            Id = Guid.NewGuid(),
            EmployeeId = Domain.Utils.EmployeeUtils.GenerateEmployeeId(),
            FirstName = "Jack",
            LastName = "Doe",
            ManagerId = _director.Id,
            Roles = new List<Role>
            {
                salesRole
            }
        }).Entity;

        context.SaveChanges();
    }

    [Test]
    public void GetEmployees()
    {
        var employees = _employeeService.GetAllEmployees();

        Assert.That(employees.Count, Is.EqualTo(3));
        Assert.That(employees.Select(x => x.FirstName), Is.EquivalentTo(new[] { "John", "Jane", "Jack" }));
    }

    [Test]
    public void GetDirectors()
    {
        var directors = _employeeService.GetDirectors();

        Assert.That(directors.Count, Is.EqualTo(1));
        Assert.That(directors.Select(x => x.FirstName), Is.EquivalentTo(new[] { "John" }));
    }

    [Test]
    public async Task GetEmployeeById()
    {
        var employee = await _employeeService.GetEmployeeById(_director.Id);
        Assert.Multiple(() =>
        {
            Assert.That(employee.FirstName, Is.EqualTo("John"));
            Assert.That(employee.LastName, Is.EqualTo("Doe"));
            Assert.That(employee.Roles, Has.Count.EqualTo(1));
        });
        Assert.That(employee.Roles.First().Name, Is.EqualTo("Director"));
    }

    [Test]
    public async Task AddEmployee()
    {
        var managerId = _director.Id;
        var roleIds = new List<Guid>
        {
            _director.Roles.First().Id
        };

        var newEmployeeId = await _employeeService.AddEmployee("John", "Doe", managerId, roleIds);

        var employee = await _employeeService.GetEmployeeById(newEmployeeId);

        Assert.That(employee.FirstName, Is.EqualTo("John"));
        Assert.That(employee.LastName, Is.EqualTo("Doe"));
        Assert.That(employee.Roles.Count, Is.EqualTo(1));
        Assert.That(employee.Roles.First().Name, Is.EqualTo("Director"));
    }

    [Test]
    public async Task UpdateEmployee()
    {
        var managerId = _director.Id;
        var roleIds = new List<Guid>
        {
            _director.Roles.First().Id
        };

        var newEmployeeId = await _employeeService.AddEmployee("John", "Doe", managerId, roleIds);

        var employee = await _employeeService.GetEmployeeById(newEmployeeId);

        Assert.That(employee.FirstName, Is.EqualTo("John"));
        Assert.That(employee.LastName, Is.EqualTo("Doe"));
        Assert.That(employee.Roles.Count, Is.EqualTo(1));
        Assert.That(employee.Roles.First().Name, Is.EqualTo("Director"));

        await _employeeService.UpdateEmployee(newEmployeeId, "Jane", "Doe");

        employee = await _employeeService.GetEmployeeById(newEmployeeId);

        Assert.That(employee.FirstName, Is.EqualTo("Jane"));
        Assert.That(employee.LastName, Is.EqualTo("Doe"));
        Assert.That(employee.Roles.Count, Is.EqualTo(1));
        Assert.That(employee.Roles.First().Name, Is.EqualTo("Director"));
    }

    [Test]
    public void GetEmployeesByManager()
    {
        var employees = _employeeService.GetEmployeesByManager(_director.Id);

        Assert.That(employees.Count, Is.EqualTo(2));
        Assert.That(employees.Select(x => x.FirstName), Is.EquivalentTo(new[] { "Jane", "Jack" }));
    }
}