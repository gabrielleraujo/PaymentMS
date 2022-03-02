using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.ApplicationService.Interfaces
{
    public interface IPaymentApplicationService<T> where T : PaymentDto
    {
        Task<ReadPaymentDto<T>> GetByIdAsync(Guid id);
        Task<ReadPaymentDto<T>> GetByPurchaseIdAsync(int purchaseId);
        Task<IEnumerable<ReadPaymentDto<T>>> ListAsync();
    }
}