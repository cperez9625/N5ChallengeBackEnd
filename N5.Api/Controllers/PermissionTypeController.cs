using Microsoft.AspNetCore.Mvc;
using N5.Data.Interfaces;
using N5.Shared;

namespace N5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : Controller
    {
        private readonly ICRUDData<PermissionType> _permissionTypeRepository;
        public PermissionTypeController(ICRUDData<PermissionType> permissionTypeRepository)
        {
            _permissionTypeRepository = permissionTypeRepository;
        }

        [HttpGet]
        public IActionResult GetPermissionTypes()
        {
            return Ok(_permissionTypeRepository.ItemList());
        }

        [HttpGet("{id}")]
        public IActionResult GetPermissionTypeById(int id)
        {
            return Ok(_permissionTypeRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult RequestPermissionType([FromBody] PermissionType permissionType)
        {
            if (permissionType == null)
                return BadRequest();

            if (String.IsNullOrEmpty(permissionType.Description))
                ModelState.AddModelError("Description", "The Description Shouldn't Be Empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPermissionType = _permissionTypeRepository.CreateItem(permissionType);

            return Created("permissionType", createdPermissionType);
        }

        [HttpPut]
        public IActionResult UpdatePermissionType([FromBody] PermissionType permissionType)
        {
            if (permissionType == null)
                return BadRequest();

            if (String.IsNullOrEmpty(permissionType.Description))
                ModelState.AddModelError("Description", "The Description Shouldn't Be Empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(_permissionTypeRepository.GetById(permissionType.Id) == null)
                return NotFound();

            var updatedPermissionType = _permissionTypeRepository.UpdateItem(permissionType);

            return Created("permissionType", updatedPermissionType);
        }
    }
}
