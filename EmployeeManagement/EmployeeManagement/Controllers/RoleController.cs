using EmployeeManagement.Domain.Contracts;
using EmployeeManagement.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RoleController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return _rolesService.GetAllRoles();
        }
    }
}
