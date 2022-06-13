using MediatR;
using N5.Shared;

namespace N5.Data.Commands
{
    public record InsertPermissionCommand(Permission permission) : IRequest<Permission>;
}
