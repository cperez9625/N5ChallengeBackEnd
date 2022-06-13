using MediatR;
using N5.Data.Interfaces;
using N5.Data.Queries;
using N5.Shared;

namespace N5.Data.Handler
{
    internal class GetAllPermissionTypesHandler : IRequestHandler<GetAllPermissionTypesQuery, List<PermissionType>>
    {
        private readonly ICRUDData<PermissionType> _permissionTypeRepository;
        public GetAllPermissionTypesHandler(ICRUDData<PermissionType> permissionTypeRepository)
        {
            _permissionTypeRepository = permissionTypeRepository;
        }

        public async Task<List<PermissionType>> Handle(GetAllPermissionTypesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_permissionTypeRepository.ItemList());
        }
    }
}
