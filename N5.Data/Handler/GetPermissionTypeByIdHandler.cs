using MediatR;
using N5.Data.Interfaces;
using N5.Data.Queries;
using N5.Shared;

namespace N5.Data.Handler
{
    internal class GetPermissionTypeByIdHandler : IRequestHandler<GetPermissionTypeByIdQuery, PermissionType>
    {
        private readonly ICRUDData<PermissionType> _permissionTypeRepository;
        public GetPermissionTypeByIdHandler(ICRUDData<PermissionType> permissionTypeRepository)
        {
            _permissionTypeRepository = permissionTypeRepository;
        }
        public async Task<PermissionType> Handle(GetPermissionTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_permissionTypeRepository.GetById(request.id));
        }
    }
}
