using SubscripManager.domain.Entities;

namespace SubscripManager.domain.Interfaces
{
    public interface IUsersRepository
    {
        User Create(User user);
        User Update(Guid id, User user);
        bool Remove(Guid id);
        List<User> GetUsers();
        User GetUserById(Guid id);
    }
}
