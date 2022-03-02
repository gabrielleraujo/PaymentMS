using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.ApplicationService.Interfaces
{
    public interface ICreditCardApplicationService<T> : IPaymentApplicationService<T> where T : CreditCardDto
    {
        Task<ReadPaymentDto<CreditCardDto>> AddAuthorizedAsync(PaymentInput<T> paymentDto);
        Task<ReadPaymentDto<CreditCardDto>> AddUnauthorizedAsync(PaymentInput<T> paymentDto);
    }
}