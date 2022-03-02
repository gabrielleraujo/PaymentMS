using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.DomainService.Interfaces
{
    public interface IDebitCardDomainService<T> : IPaymentDomainService<T> where T : DebitCardDto
    {
        Task<ReadPaymentDto<DebitCardDto>> AddAuthorizedAsync(DebitCardDto paymentDto);
        Task<ReadPaymentDto<DebitCardDto>> AddUnauthorizedAsync(DebitCardDto paymentDto);
    }
}