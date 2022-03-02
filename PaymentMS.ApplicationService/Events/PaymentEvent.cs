using PaymentMS.ApplicationService.Events.Interfaces;
using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.ApplicationService.Events
{
    public class PaymentEvent : IPaymentEvent
    {
        public event IPaymentEvent.AuthorizedEvent Authorized;
        public event IPaymentEvent.UnauthorizedEvent Unauthorized;

        public async Task InvokeAuthorized(PaymentDto payment)
        {
            await Authorized.Invoke(payment);
        }

        public async Task InvokeUnauthorized(string content, string message, PaymentDto payment)
        {
            await Unauthorized.Invoke(content, message, payment);
        }
    }
}