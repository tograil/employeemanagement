using AutoMapper;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Models;

namespace EmployeeManagement.Maps;

public class MainProfile : Profile
{
    public MainProfile()
    {
        MapEmployee();
    }

    private void MapEmployee()
    {
        CreateMap<Employee, EmployeeModel>();
    }
}