using PaymentMS.Domain.Models.States;
using PaymentMS.Domain.Models.States.Interfaces;

namespace PaymentMS.Domain.Models.Entities
{
    public class Boleto : Payment
    {
        private Boleto() { }

        public Boleto(Guid id, string barCode, DateTime dueDate,
            int purchaseId, IPaymentState state)
            : base(id, purchaseId, state)
        {
            BarCode = barCode;
            DueDate = dueDate;
        }

        public string BarCode { get; private set; }
        public DateTime DueDate { get; private set; }

        public override double CalculateDiscount() => AmountToBePaid - (AmountToBePaid * 0.05);
    }
}