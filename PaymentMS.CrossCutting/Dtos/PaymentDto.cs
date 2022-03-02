namespace PaymentMS.CrossCutting.Dtos
{
	public abstract class PaymentDto
	{
		public int PurchaseId { get; set; }
		public double AmountToBePaid { get; set; }

        public override string ToString()
        {
            return $"PurchaseId: {PurchaseId}\nAmount To Be Paid: {AmountToBePaid}";
        }
    }
}