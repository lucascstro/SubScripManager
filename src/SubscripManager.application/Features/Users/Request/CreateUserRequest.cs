using MediatR;
using SubscripManager.application.Features.Users.Dto;
using SubscripManager.domain.Entities;

namespace SubscripManager.application.Features.Users.Request
{
    public sealed record CreateUserRequest(User User) : IRequest<UserDTO>;
}