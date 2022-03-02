using PaymentMS.Domain.Models.Entities;

namespace PaymentMS.Domain.Models.States.Interfaces
{
    public interface IPaymentState
    {
        void ApplyDiscont(Payment payment);
        void PaymentValidation(Payment payment);
        void AuthorizedPayment(Payment payment);
        void UnauthorizedPayment(Payment payment);
    }
}