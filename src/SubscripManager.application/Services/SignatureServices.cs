using SubscripManager.application.DTO;
using SubscripManager.application.Interfaces;
using SubscripManager.domain.Entities;
using SubscripManager.domain.Entities.Enum;
using SubscripManager.domain.Interfaces;

namespace SubscripManager.application.Services
{
    public class SignatureServices : ISignatureServices
    {
        private readonly ISignatureRepository _signatureRepository; 
        public SignatureServices(ISignatureRepository signatureRepository) 
        {
            _signatureRepository = signatureRepository;
        }
        public Signature Create(Signature signature)
        {
            return _signatureRepository.Create(signature);
        }

        public Signature GetById(Guid id)
        {
            return _signatureRepository.GetById(id);
        }

        public List<Signature> GetByUserId(Guid UserId)
        {
            return _signatureRepository.GetByUserId(UserId);
        }

        public List<Signature> GetByUserIdAndByStatus(Guid userId, Status status)
        {
            return _signatureRepository.GetByUserIdAndByStatus(userId, status);
        }

        public Signature Update(Guid id, Signature signatures)
        {
           return _signatureRepository.Update(id, signatures);
        }

        public MonthlyExpencesDTO GetMonthlyExpences(Guid userId){
            var monthlyExpences = new MonthlyExpencesDTO();

            var allSignatures = _signatureRepository.GetByUserIdAndByStatus(userId, Status.Ativa);            
            var totalSum = allSignatures.Sum(x => x.Value);

            monthlyExpences.Signatures = allSignatures;
            monthlyExpences.TotalValue = totalSum;

            return monthlyExpences;
        }
    }
}