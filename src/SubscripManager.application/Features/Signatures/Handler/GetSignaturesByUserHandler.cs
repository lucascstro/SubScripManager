using MediatR;
using SubscripManager.application.Features.Signatures.Dto;
using SubscripManager.application.Features.Signatures.Request;
using SubscripManager.domain.Interfaces;

namespace SubscripManager.application.Features.Signatures.Handler
{
    public sealed class GetSignaturesByUserHandler : IRequestHandler<GetSignaturesByUserRequest, List<SignatureDTO>>
    {
        private readonly ISignatureRepository _signatureRepository;

        public GetSignaturesByUserHandler(ISignatureRepository signatureRepository)
        {
            _signatureRepository = signatureRepository;
        }

        public Task<List<SignatureDTO>> Handle(GetSignaturesByUserRequest request, CancellationToken cancellationToken)
        {
            try{
                var signatures = new List<SignatureDTO>();
                var ret = _signatureRepository.GetByUserId(request.UserId);

                ret.ForEach(item =>
                {
                    signatures.Add(new SignatureDTO(item.Id, item.NameService, item.Value, item.PaymentDay, item.Status, item.Categories, item.UserId));
                });

                return Task.FromResult(signatures);
            }catch
            {
                throw;
            }
        }
    }
}