using MediatR;
using SubscripManager.application.Features.Users.Dto;
using SubscripManager.application.Features.Users.Request;
using SubscripManager.domain.Interfaces;

namespace SubscripManager.application.Features.Users.Handler
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, UserDTO>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<UserDTO> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var ret = _userRepository.Create(request.User);
            return Task.FromResult(new UserDTO(ret.Id, ret.Name, ret.Email, ret.Signatures));
        }
    }
}