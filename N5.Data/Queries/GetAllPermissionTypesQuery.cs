using MediatR;
using N5.Shared;

namespace N5.Data.Queries
{
    public record GetAllPermissionTypesQuery : IRequest<List<PermissionType>>;
}
