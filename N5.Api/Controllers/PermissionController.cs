using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5.Api.Models;
using N5.Data;
using N5.Data.Commands;
using N5.Data.Queries;
using N5.Shared;

namespace N5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : Controller
    {
        private readonly N5ChallengeContext _n5ChallengeContext;
        private readonly IMediator _mediator;
        public PermissionController(N5ChallengeContext n5ChallengeContext, IMediator mediator)
        {
            _n5ChallengeContext = n5ChallengeContext;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Permission>> GetPermission() => await _mediator.Send(new GetAllPermissionsQuery());
       
        [HttpGet("{id}")]
        public async Task<Permission> GetPermissionById(int id) => await _mediator.Send(new GetPermissionByIdQuery(id));
        
        [HttpPost]
        public async Task<Permission> RequestPermission([FromBody] PermissionRequest permission)
        {
            if (String.IsNullOrEmpty(permission.EmployeeFirstName) || String.IsNullOrEmpty(permission.EmployeeLastName) || permission.PermissionType == 0)
                ModelState.AddModelError("FirstName/LastName/PermissionType", "The FirstName, LastName or PermissionType shouldn't be empty");

            Permission permissionEntity = new()
            {
                EmployeeFirstName = permission.EmployeeFirstName,
                EmployeeLastName = permission.EmployeeLastName,
                PermissionType = permission.PermissionType,
                Id = permission.Id,
                PermissionDate = DateTime.Now,
            };

            return await _mediator.Send(new InsertPermissionCommand(permissionEntity));
        }

        [HttpPut]
        public async Task<Permission> UpdatePermissionType([FromBody] PermissionRequest permission)
        {
            if (String.IsNullOrEmpty(permission.EmployeeFirstName) || String.IsNullOrEmpty(permission.EmployeeLastName) || permission.PermissionType == 0)
                ModelState.AddModelError("FirstName/LastName/PermissionType", "The FirstName, LastName or PermissionType shouldn't be empty");

            Permission permissionEntity = new()
            {
                EmployeeFirstName = permission.EmployeeFirstName,
                EmployeeLastName = permission.EmployeeLastName,
                PermissionType = permission.PermissionType,
                Id = permission.Id,
                PermissionDate = DateTime.Now,
            };

            return await _mediator.Send(new UpdatePermissionCommand(permissionEntity));
        }
    }
}
