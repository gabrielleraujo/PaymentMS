namespace PaymentMS.CrossCutting.Dtos
{
	public class BoletoDto : PaymentDto
	{
		public string BarCode { get; set; }
		public DateTime DueDate { get; set; }
	}
}