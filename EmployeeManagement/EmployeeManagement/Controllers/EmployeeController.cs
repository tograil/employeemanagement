﻿using AutoMapper;
using EmployeeManagement.Domain.Contracts;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {
            return _mapper.Map<IEnumerable<EmployeeModel>>(_employeeService.GetAllEmployees());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<EmployeeModel> Get(Guid id)
        {
            return _mapper.Map<EmployeeModel>(await _employeeService.GetEmployeeById(id));
        }

        [HttpGet("manager/{id}")]
        public IEnumerable<EmployeeModel> GetByManager(Guid id)
        {
            return _mapper.Map<IEnumerable<EmployeeModel>>(_employeeService.GetEmployeesByManager(id));
        }

        [HttpGet("role/{id}")]
        public IEnumerable<EmployeeModel> GetByRole(Guid id)
        {
            return _mapper.Map<IEnumerable<EmployeeModel>>(_employeeService.GetEmployeesByRole(id));
        }

        [HttpGet("directors")]
        public IEnumerable<EmployeeModel> GetDirectors()
        {
            return _mapper.Map<IEnumerable<EmployeeModel>>(_employeeService.GetDirectors());
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task Post([FromBody] NewEmployeeModel value)
        {
            await _employeeService.AddEmployee(value.FirstName, value.LastName, value.ManagerId, value.Roles);
        }
    }
}
