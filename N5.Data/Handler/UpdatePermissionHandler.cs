using MediatR;
using N5.Data.Commands;
using N5.Data.Interfaces;
using N5.Shared;

namespace N5.Data.Handler
{
    public class UpdatePermissionHandler : IRequestHandler<UpdatePermissionCommand, Permission>
    {
        private readonly ICRUDData<Permission> _permissionRepository;
        public UpdatePermissionHandler(ICRUDData<Permission> permissionTypeRepository)
        {
            _permissionRepository = permissionTypeRepository;
        }
        public async Task<Permission> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_permissionRepository.UpdateItem(request.permission));
        }
    }
}
