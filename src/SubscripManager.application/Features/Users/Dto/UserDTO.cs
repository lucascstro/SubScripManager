using SubscripManager.domain.Entities;

namespace SubscripManager.application.Features.Users.Dto
{
    public sealed record UserDTO
    (
        Guid Id,
        string Name,
        string Email,
        List<Signature> Signatures
    );
}