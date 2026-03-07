using MediatR;
using SubscripManager.application.Features.Signatures.Dto;
using SubscripManager.domain.Entities;

namespace SubscripManager.application.Features.Signatures.Request
{
    public sealed record CreateSignatureRequest(Signature Signature) : IRequest<SignatureDTO>;
}