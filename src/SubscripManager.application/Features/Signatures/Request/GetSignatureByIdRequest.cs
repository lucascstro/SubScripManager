using MediatR;
using SubscripManager.application.Features.Signatures.Dto;

namespace SubscripManager.application.Features.Signatures.Request
{
    public sealed record GetSignatureByIdRequest(Guid Id) : IRequest<SignatureDTO>;
}