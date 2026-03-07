using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SubscripManager.application.Features.Signatures.Dto;
using SubscripManager.domain.Entities;

namespace SubscripManager.application.Features.Signatures.Request
{
    public sealed record UpdateSignatureRequest(Guid Id, Signature Signature) : IRequest<SignatureDTO>;
}