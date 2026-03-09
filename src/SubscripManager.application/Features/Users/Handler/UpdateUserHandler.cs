using MediatR;
using SubscripManager.application.Features.Users.Dto;
using SubscripManager.application.Features.Users.Request;
using SubscripManager.domain.Interfaces;

namespace SubscripManager.application.Features.Users.Handler
{
    public sealed class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UserDTO>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserDTO> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var ret = _userRepository.Update(request.Id, request.User);
            return Task.FromResult(new UserDTO(ret.Id, ret.Name, ret.Email, ret.Signatures));
        }
    }
}