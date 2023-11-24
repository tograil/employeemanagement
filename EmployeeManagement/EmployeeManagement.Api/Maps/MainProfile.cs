using AutoMapper;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Api.Maps;

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