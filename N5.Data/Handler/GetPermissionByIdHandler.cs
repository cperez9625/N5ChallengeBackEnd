using MediatR;
using N5.Data.Interfaces;
using N5.Data.Queries;
using N5.Shared;

namespace N5.Data.Handler
{
    public class GetPermissionByIdHandler : IRequestHandler<GetPermissionByIdQuery, Permission>
    {
        private readonly ICRUDData<Permission> _permissionRepository;
        public GetPermissionByIdHandler(ICRUDData<Permission> permissionTypeRepository)
        {
            _permissionRepository = permissionTypeRepository;
        }

        public async Task<Permission> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_permissionRepository.GetById(request.id));
        }
 
    }
}
