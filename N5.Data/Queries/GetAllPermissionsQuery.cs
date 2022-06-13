using MediatR;
using N5.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Data.Queries
{
    public record GetAllPermissionsQuery: IRequest<List<Permission>>;
}
