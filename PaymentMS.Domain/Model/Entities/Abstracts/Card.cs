using PaymentMS.Domain.Models.States.Interfaces;

namespace PaymentMS.Domain.Models.Entities
{
    public abstract class Card : Payment
    {
        protected Card() { }

        public Card(Guid id, 
            string number, string agency,
            int purchaseId, IPaymentState state)
            : base(id, purchaseId, state)
        {
            Number = number;
            Agency = agency;
        }

        public string Number { get; private set; }
        public string Agency { get; private set; }
    }
}