using MediatR;
using SubscripManager.application.Features.Users.Dto;
using SubscripManager.application.Features.Users.Request;
using SubscripManager.domain.Interfaces;

namespace SubscripManager.application.Features.Users.Handler
{
    public sealed class GetUsersHandler : IRequestHandler<GetUsersRequest, List<UserDTO>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        Task<List<UserDTO>> IRequestHandler<GetUsersRequest, List<UserDTO>>.Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetUsers();
            var usersDto = new List<UserDTO>();
            users.ForEach(item =>
            {
                usersDto.Add(new UserDTO(
                    item.Id,
                    item.Name,
                    item.Email,
                    item.Signatures
                ));
            });

            return Task.FromResult(usersDto);
        }
    }
}