using SubscripManager.domain.Entities;
using SubscripManager.domain.Entities.Enum;
using SubscripManager.domain.Interfaces;
using SubscripManager.infra.Context;

namespace SubscripManager.infra.Repositories
{
    public class SignatureRepository : ISignatureRepository
    {
        private readonly AppDbContext _ctx;

        public SignatureRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public Signature Create(Signature signature)
        {
            try
            {
                if(!_ctx.Signatures.Any(x=>x.Id == signature.Id)) 
                {
                    _ctx.Signatures.Add(signature);
                    _ctx.SaveChanges();
                }   
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
                return _ctx.Signatures.FirstOrDefault(x=>x.Id == id);
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
                return _ctx.Signatures.Where(x => x.UserId == userId).ToList();
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
                return _ctx.Signatures.Where(x => x.UserId == userId && x.Status == status).ToList();
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
                var signatureItem = _ctx.Signatures.FirstOrDefault(x => x.Id == id);
                if (signatureItem == null) return null;

                _ctx.Signatures.Remove(signatureItem);
                _ctx.Signatures.Add(signatures);
                _ctx.SaveChanges();

                return signatures;
            }
            catch
            {
                throw;
            }
        }
    }
}
