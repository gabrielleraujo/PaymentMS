using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.ApplicationService.Events.Interfaces
{
    public interface IPaymentEvent
    {
        delegate Task AuthorizedEvent(PaymentDto payment);
        delegate Task UnauthorizedEvent(string content, string message, PaymentDto payment);

        event AuthorizedEvent Authorized;
        event UnauthorizedEvent Unauthorized;

        Task InvokeAuthorized(PaymentDto payment);
        Task InvokeUnauthorized(string content, string message, PaymentDto payment);
    }
}