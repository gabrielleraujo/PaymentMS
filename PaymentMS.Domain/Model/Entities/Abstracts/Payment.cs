using PaymentMS.Domain.Models.States;
using PaymentMS.Domain.Models.States.Interfaces;

namespace PaymentMS.Domain.Models.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment() { }

        protected Payment(Guid id,
            int purchaseId, IPaymentState state)
            : base(id)
        {
            PurchaseId = purchaseId;
            State = state;
        }

        public int PurchaseId { get; private set; }
        public double AmountToBePaid { get; private set; }
        public IPaymentState State { get; internal set; }


        public abstract double CalculateDiscount();
        public void ApplyDiscount()
        {
            State.ApplyDiscont(this);
            AmountToBePaid = CalculateDiscount();
        }
        
        public void AuthorizedPayment() 
        { 
            State.AuthorizedPayment(this); 
        }

        public void UnauthorizedPayment() 
        { 
            State.UnauthorizedPayment(this); 
        }
    }
}