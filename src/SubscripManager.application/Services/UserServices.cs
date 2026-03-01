using SubscripManager.application.Interfaces;
using SubscripManager.domain.Entities;
using SubscripManager.domain.Interfaces;

namespace SubscripManager.application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public User GetUserById(Guid id)
        {
            return _userRepository.GetUserById(id);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public User Update(Guid id, User user)
        {
            return _userRepository.Update(id, user);
        }
    }
}
