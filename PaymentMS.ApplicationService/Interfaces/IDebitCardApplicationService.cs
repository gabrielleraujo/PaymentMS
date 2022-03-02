using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.ApplicationService.Interfaces
{
    public interface IDebitCardApplicationService<T> : IPaymentApplicationService<T> where T : DebitCardDto
    {
        Task<ReadPaymentDto<DebitCardDto>> AddAuthorizedAsync(PaymentInput<T> paymentDto);
        Task<ReadPaymentDto<DebitCardDto>> AddUnauthorizedAsync(PaymentInput<T> paymentDto);
    }
}