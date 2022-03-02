using PaymentMS.Domain.Models.Entities;

namespace PaymentMS.Infrastructure.Data.Repository
{
    public interface IPaymentRepository<T> : IBaseRepository<T> where T : Payment
    {
    }
}