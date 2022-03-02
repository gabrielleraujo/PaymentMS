namespace PaymentMS.CrossCutting.Dtos
{
	public class CardDto : PaymentDto
	{
		public string Number { get; set; }
		public string Agency { get; set; }
	}
}