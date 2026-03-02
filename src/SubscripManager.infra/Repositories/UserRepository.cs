using SubscripManager.domain.Entities;
using SubscripManager.domain.Interfaces;

namespace SubscripManager.infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _user = new();
        public User Create(User user)
        {
            try
            {
                if (!_user.Any(x => x.Id == user.Id))
                    _user.Add(user);
            }
            catch { throw; }

            return user;
        }

        public User GetUserById(Guid id)
        {
            try
            {
                return _user.FirstOrDefault(x => x.Id == id);
            }
            catch { 
                throw; 
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                return _user;
            }
            catch
            {
                throw;
            }
        }

        public User Update(Guid id, User user)
        {
            try
            {
                var userItem = _user.FirstOrDefault(x => x.Id == id);
                if (userItem == null) return null;

                var idx = _user.IndexOf(userItem);
                _user[idx] = user;

                return _user[idx];
            }
            catch
            {
                throw;
            }
        }
    }
}
