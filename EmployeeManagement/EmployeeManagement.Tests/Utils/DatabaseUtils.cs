using EmployeeManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Tests.Utils;

public class DatabaseUtils
{
    public static EmployeeContext GetInMemoryDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<EmployeeContext>()
            .UseInMemoryDatabase(databaseName: "EmployeeManagement")
            .Options;

        var context = new EmployeeContext(options);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        return context;
    }
}