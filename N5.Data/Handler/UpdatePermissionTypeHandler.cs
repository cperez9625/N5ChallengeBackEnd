using MediatR;
using N5.Data.Commands;
using N5.Data.Interfaces;
using N5.Shared;

namespace N5.Data.Handler
{
    public class UpdatePermissionTypeHandler : IRequestHandler<UpdatePermissionTypeCommand, PermissionType>
    {
        private readonly ICRUDData<PermissionType> _permissionTypeRepository;
        public UpdatePermissionTypeHandler(ICRUDData<PermissionType> permissionTypeRepository)
        {
            _permissionTypeRepository = permissionTypeRepository;
        }

        public async Task<PermissionType> Handle(UpdatePermissionTypeCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_permissionTypeRepository.UpdateItem(request.permission));
        }
    }
}
