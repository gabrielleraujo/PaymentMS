namespace PaymentMS.CrossCutting.Dtos
{
	public class CreditCardDto : CardDto
	{
		public int NumberInstallments { get; set; }
		public int NumberInstallmentsPaid { get; set; }
		public float InstallmentValue { get; set; }
		public float TotalInterest { get; set; }
	}
}