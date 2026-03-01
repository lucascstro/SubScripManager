using SubscripManager.domain.Entities;

namespace SubscripManager.domain.Interfaces
{
    public interface ISignaturesRepository
    {
        Signature Create(Signature user);
        Signature Update(Guid id, Signature signatures);
        Signature GetByUserId(Guid UserId);
        Signature GetById(Guid id);
    }
}