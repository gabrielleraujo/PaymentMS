using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.DomainService.Interfaces
{
    public interface ICreditCardDomainService<T> : IPaymentDomainService<T> where T : CreditCardDto
    {
        Task<ReadPaymentDto<CreditCardDto>> AddAuthorizedAsync(CreditCardDto paymentDto);
        Task<ReadPaymentDto<CreditCardDto>> AddUnauthorizedAsync(CreditCardDto paymentDto);
    }
}