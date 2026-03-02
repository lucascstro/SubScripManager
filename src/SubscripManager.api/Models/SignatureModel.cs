using SubscripManager.domain.Entities.Enum;

namespace SubscripManager.api.Models
{
    public class SignatureModel
    {
        public string NameService { get; set; }
        public Decimal Value { get; set; }
        public int PaymentDay { get; set; }
        public Status Status { get; set; }
        public Categories Categories { get; set; }
        public Guid UserId { get; set; }
    }
}
