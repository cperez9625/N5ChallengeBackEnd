using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5.Data;
using N5.Data.Commands;
using N5.Data.Queries;
using N5.Shared;

namespace N5.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : Controller
    {
        private readonly N5ChallengeContext _n5ChallengeContext;
        private readonly IMediator _mediator;
        public PermissionTypeController(N5ChallengeContext n5ChallengeContext, IMediator mediator)
        {
            _n5ChallengeContext = n5ChallengeContext;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<PermissionType>> GetPermissionTypes() => await _mediator.Send(new GetAllPermissionTypesQuery());

        [HttpGet("{id}")]
        public async Task<PermissionType> GetPermissionTypeById(int id) => await _mediator.Send(new GetPermissionTypeByIdQuery(id));

        [HttpPost]
        public async Task<PermissionType> RequestPermissionType([FromBody] PermissionType permissionType)
        {
            if (String.IsNullOrEmpty(permissionType.Description))
                ModelState.AddModelError("Description", "The Description Shouldn't Be Empty");

            return await _mediator.Send(new InsertPermissionTypeCommand(permissionType));
        }

        [HttpPut]
        public async Task<PermissionType> UpdatePermissionType([FromBody] PermissionType permissionType)
        {
            if (String.IsNullOrEmpty(permissionType.Description))
                ModelState.AddModelError("Description", "The Description Shouldn't Be Empty");

            return await _mediator.Send(new UpdatePermissionTypeCommand(permissionType));
        }
    }
}
