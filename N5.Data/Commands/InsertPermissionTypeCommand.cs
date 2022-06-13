using MediatR;
using N5.Shared;

namespace N5.Data.Commands
{
    public record InsertPermissionTypeCommand(PermissionType permission) : IRequest<PermissionType>;
}
