using EmployeeManagement.Domain.Contracts;
using EmployeeManagement.Infrastructure.Services;
using EmployeeManagement.Tests.Utils;

namespace EmployeeManagement.Tests.Roles;

[TestFixture]
public class RolesTests
{
    private IRolesService _roleService = null!;
    private int _numberOfRoles = 0;

    private readonly string[] _roleNames = new[]
    {
        "Director",
        "IT",
        "Support",
        "Analyst",
        "Sales", "Accounting"
    };

    [SetUp]                               
    public void Setup()                   
    {                                     
        var context = DatabaseUtils.GetInMemoryDatabaseContext();
        _numberOfRoles = context.Roles.Count();
        _roleService = new RolesService(context);
    }

    [Test]
    public void GetRoles()
    {
        var roles = _roleService.GetAllRoles();

        Assert.That(roles.Count, Is.EqualTo(_numberOfRoles));
        Assert.That(roles.Select(x => x.Name), Is.EquivalentTo(_roleNames));
    }

}