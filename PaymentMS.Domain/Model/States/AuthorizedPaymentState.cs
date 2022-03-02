using PaymentMS.Domain.Models.States.Interfaces;
using PaymentMS.Domain.Models.Entities;

namespace PaymentMS.Domain.Models.States
{
    public class AuthorizedPaymentState : IPaymentState
    {
        public void PaymentValidation(Payment payment)
        {
            throw new NotImplementedException("PaymentValidation has already been resolved");
        }

        public void ApplyDiscont(Payment payment)
        {
            throw new NotImplementedException("ApplyDiscont has already been resolved");
        }

        public void AuthorizedPayment(Payment payment)
        {
            throw new NotImplementedException("AuthorizedPayment has already been resolved");
        }

        public void UnauthorizedPayment(Payment payment)
        {
            throw new NotImplementedException("UnauthorizedPayment has already been resolved");
        }
    }
}