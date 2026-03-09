using MediatR;
using SubscripManager.application.Features.Users.Dto;
using SubscripManager.domain.Entities;

namespace SubscripManager.application.Features.Users.Request
{
    public sealed record UpdateUserRequest(Guid Id, User User) : IRequest<UserDTO>;
}