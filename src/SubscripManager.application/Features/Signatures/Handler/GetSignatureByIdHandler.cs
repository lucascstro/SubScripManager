using MediatR;
using SubscripManager.application.Features.Signatures.Dto;
using SubscripManager.application.Features.Signatures.Request;
using SubscripManager.domain.Interfaces;

namespace SubscripManager.application.Features.Signatures.Handler
{
    public sealed class GetSignatureByIdHandler : IRequestHandler<GetSignatureByIdRequest, SignatureDTO>
    {
        private readonly ISignatureRepository _signatureRepository;

        public GetSignatureByIdHandler(ISignatureRepository signatureRepository)
        {
            _signatureRepository = signatureRepository;
        }

        public Task<SignatureDTO> Handle(GetSignatureByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var ret = _signatureRepository.GetById(request.Id);
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