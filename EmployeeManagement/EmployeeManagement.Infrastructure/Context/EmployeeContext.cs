using EmployeeManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Context;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Employee>()
            .Property(e => e.ManagerId)
            .IsRequired(false);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Manager)
            .WithMany()
            .HasForeignKey(e => e.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Roles)
            .WithMany(r => r!.Employees);

        modelBuilder.Entity<Role>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Role>()
            .HasData(
                new Role { Id = Guid.NewGuid(), Name = "Director" },
                new Role { Id = Guid.NewGuid(), Name = "IT" },
                new Role { Id = Guid.NewGuid(), Name = "Support" },
                new Role { Id = Guid.NewGuid(), Name = "Analyst" },
                new Role { Id = Guid.NewGuid(), Name = "Sales" },
                new Role { Id = Guid.NewGuid(), Name = "Accounting" }
              );
    }
}