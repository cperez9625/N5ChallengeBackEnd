using MediatR;
using N5.Shared;

namespace N5.Data.Queries
{
    public record GetPermissionTypeByIdQuery(int id) : IRequest<PermissionType>;
}
