using PaymentMS.ApplicationService.Events;
using PaymentMS.ApplicationService.Events.Interfaces;

namespace PaymentMS.Infrastructure.IoC.Factories
{
    public class IssueInvoiceEventFactory
    {
        public static IIssueInvoiceEvent Create()
        {
            var model = new IssueInvoiceEvent();
            model.Event += SendEmailEvent.Send;
            return model;
        }
    }
}