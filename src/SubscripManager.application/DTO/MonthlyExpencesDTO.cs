using SubscripManager.domain.Entities;

namespace SubscripManager.application.DTO
{
    public class MonthlyExpencesDTO
    {
        public decimal TotalValue {get; set; }
        public List<Signature> Signatures { get; set; } = new();
    }
}
