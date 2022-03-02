namespace PaymentMS.CrossCutting.Dtos
{
    public class PaymentInput<T> where T : PaymentDto
    {
        public T PaymentDto { get; set; }
        public UserInput User { get; set; }
    }
}