using MediatR;
using SubscripManager.application.Features.Signatures.Dto;
using SubscripManager.application.Features.Signatures.Request;
using SubscripManager.domain.Interfaces;

namespace SubscripManager.application.Features.Signatures.Handler
{
    public sealed class CreateSignatureHandler : IRequestHandler<CreateSignatureRequest, SignatureDTO>
    {
        private readonly ISignatureRepository _signatureRepository;

        public CreateSignatureHandler(ISignatureRepository signatureRepository)
        {
            _signatureRepository = signatureRepository;
        }

        public Task<SignatureDTO> Handle(CreateSignatureRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var ret = _signatureRepository.Create(request.Signature);
                var signatureDTO = new SignatureDTO(ret.Id, ret.NameService, ret.Value, ret.PaymentDay, ret.Status, ret.Categories, ret.UserId);
                return Task.FromResult(signatureDTO);
            }
            catch
            {
                throw;
            }

        }
    }
}