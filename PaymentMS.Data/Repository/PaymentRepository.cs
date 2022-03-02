using PaymentMS.Data.Context;
using PaymentMS.Domain.Models.Entities;

namespace PaymentMS.Infrastructure.Data.Repository
{
    public class PaymentRepository<T> : BaseRepository<T>, IPaymentRepository<T> where T : Payment
    {
        public PaymentRepository(PaymentMSContext context) : base(context) { }
	}
}