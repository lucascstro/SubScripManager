using SubscripManager.domain.Entities.Enum;

namespace SubscripManager.domain.Entities
{
    public class Signature
    {
        public Signature(string nameService, decimal value, int paymentDay, Status status, Categories categories, Guid userId)
        {
            if (value == null || value <= 0) throw new Exception("Valor Inválido");
            if (paymentDay <= 1 && paymentDay >= 28) throw new Exception("A data de vencimento deve estar entre 1 e 28 do mês.");

            Id = Guid.NewGuid();
            NameService = nameService;
            Value = value;
            PaymentDay = paymentDay;
            Status = status;
            Categories = categories;
            UserId = userId;
        }

        public Guid Id { get; private set; }
        public string NameService { get; set; }
        public Decimal Value { get; set; }
        public int PaymentDay { get; set; }
        public Status Status { get; set; }
        public Categories Categories { get; set; }
        public Guid UserId { get; set; }
    }
}