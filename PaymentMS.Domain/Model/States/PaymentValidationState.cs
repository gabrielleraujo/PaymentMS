using PaymentMS.Domain.Models.States.Interfaces;
using PaymentMS.Domain.Models.Entities;

namespace PaymentMS.Domain.Models.States
{
    public class PaymentValidationState : IPaymentState
    {
        public void PaymentValidation(Payment payment)
        {
            throw new NotImplementedException("PaymentValidation has already been resolved");
        }

        public void ApplyDiscont(Payment payment)
        {
            payment.State = new ApplyDiscontState();
        }

        public void AuthorizedPayment(Payment payment)
        {
            throw new NotImplementedException("Cannot AuthorizedPayment yet");
        }

        public void UnauthorizedPayment(Payment payment)
        {
            throw new NotImplementedException("Cannot UnauthorizedPayment yet");
        }
    }
}