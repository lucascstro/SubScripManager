using SubscripManager.domain.Entities;

namespace SubscripManager.domain.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);
        User Update(Guid id, User user);
        List<User> GetUsers();
        User GetUserById(Guid id);
    }
}
