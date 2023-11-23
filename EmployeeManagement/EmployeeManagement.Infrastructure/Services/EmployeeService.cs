﻿using EmployeeManagement.Domain.Contracts;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace EmployeeManagement.Infrastructure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly EmployeeContext _context;

    public EmployeeService(EmployeeContext context)
    {
        _context = context;
    }

    public IList<Employee> GetEmployeesByManager(Guid managerId)
    {
        return _context.Employees
            .Include(x => x.Roles)
            .Include(x => x.Manager)
            .Where(e => e.ManagerId == managerId).ToList();
    }

    public IList<Employee> GetEmployeesByRole(Guid roleId)
    {
        return _context.Employees
            .Include(x => x.Roles)
            .Include(x => x.Manager)
            .Where(e => e.Roles.Any(role => role.Id == roleId))
            .ToList();
    }

    public IList<Employee> GetDirectors()
    {
        var directors = _context.Employees
            .Where(e => e.Roles.Any(role => role.Name == "Director"))
            .ToList();
        return directors;
    }

    public IList<Employee> GetAllEmployees()
    {
        return _context.Employees
            .Include(x => x.Roles)
            .Include(x => x.Manager)
            .ToList();
    }

    public async Task<Employee> GetEmployeeById(Guid id)
    {
        return await _context.Employees
            .Include(x => x.Roles)
            .Include(x => x.Manager)
            .FirstAsync(x => x.Id == id);
    }

    public async Task AddEmployee(string firstName, string lastName, Guid? managerId, IList<Guid> roleIds)
    {
        var newEmployee = new Employee
        {
            FirstName = firstName,
            LastName = lastName,
            ManagerId = managerId,
            Roles = new List<Role>()
        };

        foreach (var roleId in roleIds)
        {
            var role = await _context.Set<Role>().FirstOrDefaultAsync(x => x.Id == roleId);
            if (role != null)
            {
                newEmployee.Roles.Add(role);
            }
        }

        _context.Employees.Add(newEmployee);
        await _context.SaveChangesAsync();
    }
}