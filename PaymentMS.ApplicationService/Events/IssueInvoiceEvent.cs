using PaymentMS.ApplicationService.Events.Interfaces;
using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.ApplicationService.Events
{
    public class IssueInvoiceEvent : IIssueInvoiceEvent
    {
        public delegate Task Events(string content, string message, PaymentDto payment);
        public event Events Event;

        public async Task Generete(PaymentDto payment)
        {
            Console.WriteLine("Building the invoice...\nSending invoice to email...");
            await Event.Invoke("Your payment has been approved, we are sending the electronic invoice to the registered email.", "registered.email@gmail.com", payment);
        }
    }
}