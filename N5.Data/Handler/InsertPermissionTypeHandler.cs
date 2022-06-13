using MediatR;
using N5.Data.Commands;
using N5.Data.Interfaces;
using N5.Shared;

namespace N5.Data.Handler
{
    public class InsertPermissionTypeHandler : IRequestHandler<InsertPermissionTypeCommand, PermissionType>
    {
        private readonly ICRUDData<PermissionType> _permissionTypeRepository;
        public InsertPermissionTypeHandler(ICRUDData<PermissionType> permissionTypeRepository)
        {
            _permissionTypeRepository = permissionTypeRepository;
        }

        public async Task<PermissionType> Handle(InsertPermissionTypeCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_permissionTypeRepository.CreateItem(request.permission));
        }
    }
}
