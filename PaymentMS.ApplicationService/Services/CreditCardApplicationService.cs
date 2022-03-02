using PaymentMS.ApplicationService.Events.Interfaces;
using PaymentMS.CrossCutting.Dtos;
using PaymentMS.DomainService.Interfaces;

namespace PaymentMS.ApplicationService.Interfaces
{
    public class CreditCardApplicationService<T> : ICreditCardApplicationService<CreditCardDto> where T : CreditCardDto
    {
        private readonly ICreditCardDomainService<CreditCardDto> _domainService;
        private readonly IPaymentEvent _paymentEvent;

        public CreditCardApplicationService(ICreditCardDomainService<CreditCardDto> domainService, IPaymentEvent paymentEvent)
        {
            _domainService = domainService;
            _paymentEvent = paymentEvent;
        }


        public async Task<ReadPaymentDto<CreditCardDto>> AddAuthorizedAsync(PaymentInput<CreditCardDto> input)
        {
            var result = await _domainService.AddAuthorizedAsync(input.PaymentDto);
            await _paymentEvent.InvokeAuthorized(input.PaymentDto);

            return result;
        }

        public async Task<ReadPaymentDto<CreditCardDto>> AddUnauthorizedAsync(PaymentInput<CreditCardDto> input)
        {
            var result = await _domainService.AddUnauthorizedAsync(input.PaymentDto);
            await _paymentEvent.InvokeUnauthorized("Your payment has not been approved.", input.User.Email, input.PaymentDto);

            return result;
        }



        public async Task<ReadPaymentDto<CreditCardDto>> GetByIdAsync(Guid id)
        {
            var result = await _domainService.GetByIdAsync(id);
            return result;
        }

        public async Task<ReadPaymentDto<CreditCardDto>> GetByPurchaseIdAsync(int purchaseId)
        {
            var result = await _domainService.GetByPurchaseIdAsync(purchaseId);
            return result;
        }

        public async Task<IEnumerable<ReadPaymentDto<CreditCardDto>>> ListAsync()
        {
            var result = await _domainService.ListAsync();
            return result;
        }
    }
}