using SubscripManager.domain.Entities;
using SubscripManager.domain.Entities.Enum;
using SubscripManager.domain.Interfaces;

namespace SubscripManager.infra.Repositories
{
    public class SignatureRepository : ISignatureRepository
    {
        private static readonly List<Signature> _signatures = new();
        public Signature Create(Signature signature)
        {
            try
            {
                if(!_signatures.Any(x=>x.Id == signature.Id))
                    _signatures.Add(signature);
            }
            catch (Exception ex) 
            {
                throw new Exception("Falha ao criar usuário.", ex);
            }

            return signature;
        }

        public Signature GetById(Guid id)
        {
            try
            {
                return _signatures.FirstOrDefault(x=>x.Id == id);
            }
            catch 
            {
                throw;
            }
        }

        public List<Signature> GetByUserId(Guid userId)
        {
            try
            {
                return _signatures.Where(x => x.UserId == userId).ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Signature> GetByUserIdAndByStatus(Guid userId, Status status)
        {
            try
            {
                return _signatures.Where(x => x.UserId == userId && x.Status == status).ToList();
            }
            catch
            {
                throw;
            }
        }

        public Signature Update(Guid id, Signature signatures)
        {
            try
            {
                var signatureItem = _signatures.FirstOrDefault(x => x.Id == id);
                if (signatureItem == null) return null;

                var idx = _signatures.IndexOf(signatureItem);
                _signatures[idx] = signatures;

                return _signatures[idx];
            }
            catch
            {
                throw;
            }
        }
    }
}
