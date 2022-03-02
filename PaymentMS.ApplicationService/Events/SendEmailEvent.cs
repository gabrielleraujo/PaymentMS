using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.ApplicationService.Events
{
    public class SendEmailEvent
    {
        public static async Task Send(string content, string email, PaymentDto dto)
        {
            Console.WriteLine($"send to email:\n{email}");
            Console.WriteLine($"content:\n{content}");
            Console.WriteLine("Enviando email...");
            Console.WriteLine(dto.ToString());
        }
    }
}