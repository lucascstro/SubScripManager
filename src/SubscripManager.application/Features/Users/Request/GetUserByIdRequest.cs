using MediatR;
using SubscripManager.application.Features.Users.Dto;

namespace SubscripManager.application.Features.Users.Request
{
    public sealed record GetUserByIdRequest(Guid Id) : IRequest<UserDTO>;
}