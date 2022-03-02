using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.ApplicationService.Events.Interfaces
{
    public interface IIssueInvoiceEvent
    {
        Task Generete(PaymentDto payment);
    }
}