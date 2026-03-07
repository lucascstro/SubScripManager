using MediatR;
using SubscripManager.application.Features.Signatures.Dto;
using SubscripManager.application.Features.Signatures.Request;
using SubscripManager.domain.Interfaces;

namespace SubscripManager.application.Features.Signatures.Handler
{
    public class UpdateSignatureHandler : IRequestHandler<UpdateSignatureRequest, SignatureDTO>
    {
        private readonly ISignatureRepository _signatureRepository;

        public UpdateSignatureHandler(ISignatureRepository signatureRepository)
        {
            _signatureRepository = signatureRepository;
        }

        public Task<SignatureDTO> Handle(UpdateSignatureRequest request, CancellationToken cancellationToken)
        {
            var ret = _signatureRepository.GetById(request.Id);
            if (ret == null) return null;

            var retUpdate = _signatureRepository.Update(request.Id, request.Signature);

            return Task.FromResult(new SignatureDTO(retUpdate.Id, retUpdate.NameService, retUpdate.Value, retUpdate.PaymentDay, retUpdate.Status, retUpdate.Categories, retUpdate.UserId));
        }
    }
}