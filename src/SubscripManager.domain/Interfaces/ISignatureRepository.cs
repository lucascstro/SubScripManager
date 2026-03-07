using SubscripManager.domain.Entities;
using SubscripManager.domain.Entities.Enum;

namespace SubscripManager.domain.Interfaces
{
    public interface ISignatureRepository
    {
        Signature Create(Signature Signature);
        Signature Update(Guid id, Signature signatures);
        List<Signature> GetByUserId(Guid userId);
        Signature GetById(Guid id);
        List<Signature> GetByUserIdAndByStatus(Guid userId, Status status);
    }
}