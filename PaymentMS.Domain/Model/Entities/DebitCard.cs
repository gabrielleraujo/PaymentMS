using PaymentMS.Domain.Models.States;
using PaymentMS.Domain.Models.States.Interfaces;

namespace PaymentMS.Domain.Models.Entities
{
    public class DebitCard : Card
    {
        private DebitCard() { }

        public DebitCard(Guid id,
            string number, string agency, 
            int purchaseId, IPaymentState state)
            :  base (id, number, agency, purchaseId, state)
        { }

        public override double CalculateDiscount() => AmountToBePaid - (AmountToBePaid * 0.1);
    }
}