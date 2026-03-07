using MediatR;
using SubscripManager.application.Features.Signatures.Dto;

namespace SubscripManager.application.Features.Signatures.Request
{
    public sealed record GetSignaturesByUserRequest(Guid UserId) : IRequest<List<SignatureDTO>>;
}