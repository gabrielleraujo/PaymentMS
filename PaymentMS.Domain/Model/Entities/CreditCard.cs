using PaymentMS.Domain.Models.States;
using PaymentMS.Domain.Models.States.Interfaces;

namespace PaymentMS.Domain.Models.Entities
{
    public class CreditCard : Card
    {
        private CreditCard() { }

        public CreditCard(Guid id,
            string number, string agency, 
            int numberInstallments, int numberInstallmentsPaid, float installmentValue, float totalInterest,
            int purchaseId, IPaymentState state)
            : base(id, number, agency, purchaseId, state)
        {
            NumberInstallments = numberInstallments;
            NumberInstallmentsPaid = numberInstallmentsPaid;
            InstallmentValue = installmentValue;
            TotalInterest = totalInterest;
        }

        public int NumberInstallments { get; private set; }
        public int NumberInstallmentsPaid { get; private set; }
        public float InstallmentValue { get; private set; }
        public float TotalInterest { get; private set; }

        public override double CalculateDiscount() => AmountToBePaid;
    }
}