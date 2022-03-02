using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.DomainService.Interfaces
{
    public interface IPaymentDomainService<T> where T : PaymentDto
    {
        Task<ReadPaymentDto<T>> GetByIdAsync(Guid id);
        Task<ReadPaymentDto<T>> GetByPurchaseIdAsync(int purchaseId);
        Task<IEnumerable<ReadPaymentDto<T>>> ListAsync();
    }
}