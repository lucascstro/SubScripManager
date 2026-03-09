using MediatR;
using SubscripManager.application.Features.Users.Dto;
using SubscripManager.application.Features.Users.Request;
using SubscripManager.domain.Interfaces;

namespace SubscripManager.application.Features.Users.Handler
{
    public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, UserDTO>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserDTO> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var ret = _userRepository.GetUserById(request.Id);
            return Task.FromResult(new  UserDTO(ret.Id, ret.Name, ret.Email, ret.Signatures));
        }
    }

}