using MediatR;
using N5.Data.Interfaces;
using N5.Data.Queries;
using N5.Shared;

namespace N5.Data.Handler
{
    public class GetAllPermissionsHandler : IRequestHandler<GetAllPermissionsQuery, List<Permission>>
    {
        private readonly ICRUDData<Permission> _permissionRepository;
        public GetAllPermissionsHandler(ICRUDData<Permission> permissionTypeRepository)
        {
            _permissionRepository = permissionTypeRepository;
        }
        public async Task<List<Permission>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_permissionRepository.ItemList());
        }
    }
}
