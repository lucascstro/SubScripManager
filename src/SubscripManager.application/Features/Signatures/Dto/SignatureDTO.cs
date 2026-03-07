

using SubscripManager.domain.Entities.Enum;

namespace SubscripManager.application.Features.Signatures.Dto
{
    public sealed record SignatureDTO(
        Guid Id,
        string NameService,
        Decimal Value,
        int PaymentDay,
        Status Status,
        Categories Categories,
        Guid UserId
    );
}