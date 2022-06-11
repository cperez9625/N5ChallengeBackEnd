using Microsoft.AspNetCore.Mvc;
using N5.Api.Models;
using N5.Data.Interfaces;
using N5.Shared;

namespace N5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : Controller
    {
        private readonly ICRUDData<Permission> _permissionRepository;
        public PermissionController(ICRUDData<Permission> permissionTypeRepository)
        {
            _permissionRepository = permissionTypeRepository;
        }
        //public PermissionController()
        //{

        //}

        [HttpGet]
        public IActionResult GetPermission()
       {
            var testie = _permissionRepository.ItemList();
            return Ok(testie);
        }

        [HttpGet("{id}")]
        public IActionResult GetPermissionById(int id)
        {
            return Ok(_permissionRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult RequestPermission([FromBody] PermissionRequest permission)
        {
            if (permission == null)
                return BadRequest();

            if (String.IsNullOrEmpty(permission.EmployeeFirstName) || String.IsNullOrEmpty(permission.EmployeeLastName) || permission.PermissionType == 0)
                ModelState.AddModelError("FirstName/LastName/PermissionType", "The FirstName, LastName or PermissionType shouldn't be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Permission permissionEntity = new()
            {
                EmployeeFirstName = permission.EmployeeFirstName,
                EmployeeLastName = permission.EmployeeLastName,
                PermissionType = permission.PermissionType,
                Id = permission.Id,
                PermissionDate = DateTime.Now,
            };

            var createdPermission = _permissionRepository.CreateItem(permissionEntity);

            return Created("permissionType", createdPermission);
        }

        [HttpPut]
        public IActionResult UpdatePermissionType([FromBody] PermissionRequest permission)
        {
            if (permission == null)
                return BadRequest();

            if (String.IsNullOrEmpty(permission.EmployeeFirstName) || String.IsNullOrEmpty(permission.EmployeeLastName) || permission.PermissionType == 0)
                ModelState.AddModelError("FirstName/LastName/PermissionType", "The FirstName, LastName or PermissionType shouldn't be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_permissionRepository.GetById(permission.Id) == null)
                return NotFound();

            Permission permissionEntity = new()
            {
                EmployeeFirstName = permission.EmployeeFirstName,
                EmployeeLastName = permission.EmployeeLastName,
                PermissionType = permission.PermissionType,
                Id = permission.Id,
                PermissionDate = DateTime.Now,
            };

            var updatedPermission = _permissionRepository.UpdateItem(permissionEntity);

            return Created("permissionType", updatedPermission);
        }
    }
}
