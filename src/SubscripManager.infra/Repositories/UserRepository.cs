using SubscripManager.domain.Entities;
using SubscripManager.domain.Interfaces;
using SubscripManager.infra.Context;

namespace SubscripManager.infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _ctx;

        public UserRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public User Create(User user)
        {
            try
            {
                if (!_ctx.Users.Any(x => x.Id == user.Id))
                {
                    _ctx.Add(user);
                    _ctx.SaveChanges();
                }
            }
            catch { throw; }

            return user;
        }

        public User GetUserById(Guid id)
        {
            try
            {
                var usu = _ctx.Users.FirstOrDefault(x => x.Id == id);
                if(usu != null)
                    usu.Signatures = _ctx.Signatures.Where(x => x.UserId == id).ToList();

                return usu;
            }
            catch { 
                throw; 
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                return _ctx.Users.ToList();
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
                var userItem = _ctx.Users.FirstOrDefault(x => x.Id == id);
                if (userItem == null) return null;

                _ctx.Users.Remove(userItem);
                _ctx.Add(user);
                _ctx.SaveChanges();

                return user;
            }
            catch
            {
                throw;
            }
        }
    }
}
