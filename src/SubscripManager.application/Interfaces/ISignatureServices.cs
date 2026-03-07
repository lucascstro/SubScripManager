using SubscripManager.application.DTO;
using SubscripManager.domain.Entities;
using SubscripManager.domain.Entities.Enum;

namespace SubscripManager.application.Interfaces
{
    public interface ISignatureServices
    {
        Signature Create(Signature user);
        Signature Update(Guid id, Signature signatures);
        List<Signature> GetByUserId(Guid UserId);
        Signature GetById(Guid id);
        List<Signature> GetByUserIdAndByStatus(Guid UserId, Status status);
        MonthlyExpencesDTO GetMonthlyExpences(Guid userId);
    }
}