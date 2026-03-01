using SubscripManager.domain.Entities;

namespace SubscripManager.application.Interfaces
{
    public interface IUserServices
    {
        User Create(User user);
        User Update(Guid id, User user);
        List<User> GetUsers();
        User GetUserById(Guid id);
    }
}