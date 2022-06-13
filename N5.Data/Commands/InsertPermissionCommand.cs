using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using N5.Shared;

namespace N5.Data.Commands
{
    public record InsertPermissionCommand(Permission permission) : IRequest<Permission>;
}
