namespace PaymentMS.CrossCutting.Dtos
{
	public class ReadPaymentDto<T> where T : PaymentDto
    {
        public T PaymentDto { get; set; }
        public string Status { get; set; }
    }
}