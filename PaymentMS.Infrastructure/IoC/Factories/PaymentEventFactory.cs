using PaymentMS.ApplicationService.Events;
using PaymentMS.ApplicationService.Events.Interfaces;

namespace PaymentMS.Infrastructure.IoC.Factories
{
    public class PaymentEventFactory
    {
        public static IPaymentEvent Create()
        {
            var paymentEvent = new PaymentEvent();
            paymentEvent.Unauthorized += SendEmailEvent.Send;

            var issueInvoice = IssueInvoiceEventFactory.Create();

            paymentEvent.Authorized += issueInvoice.Generete;
            return paymentEvent;
        }
    }
}