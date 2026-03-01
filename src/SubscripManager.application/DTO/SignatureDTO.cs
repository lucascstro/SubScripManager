using SubscripManager.domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscripManager.application.DTO
{
    public class SignatureDTO
    {
        public SignatureDTO(string nameService, decimal value, int paymentDay, Status status, Categories categories)
        {
            NameService = nameService;
            Value = value;
            PaymentDay = paymentDay;
            Status = status;
            Categories = categories;
        }
        public string NameService { get; set; }
        public Decimal Value { get; set; }
        public int PaymentDay { get; set; }
        public Status Status { get; set; }
        public Categories Categories { get; set; }
    }
}