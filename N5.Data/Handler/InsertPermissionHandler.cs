using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using N5.Data.Commands;
using N5.Data.Interfaces;
using N5.Shared;

namespace N5.Data.Handler
{
    public class InsertPermissionHandler : IRequestHandler<InsertPermissionCommand, Permission>
    {
        private readonly ICRUDData<Permission> _permissionRepository;
        public InsertPermissionHandler(ICRUDData<Permission> permissionTypeRepository)
        {
            _permissionRepository = permissionTypeRepository;
        }

        public async Task<Permission> Handle(InsertPermissionCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_permissionRepository.CreateItem(request.permission));
        }
    }
}
