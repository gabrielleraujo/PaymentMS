using PaymentMS.ApplicationService.Events.Interfaces;
using PaymentMS.CrossCutting.Dtos;
using PaymentMS.DomainService.Interfaces;

namespace PaymentMS.ApplicationService.Interfaces
{
    public class DebitCardApplicationService<T> : IDebitCardApplicationService<DebitCardDto> where T : DebitCardDto
    {
        private readonly IDebitCardDomainService<DebitCardDto> _domainService;
        private readonly IPaymentEvent _paymentEvent;

        public DebitCardApplicationService(IDebitCardDomainService<DebitCardDto> domainService, IPaymentEvent paymentEvent)
        {
            _domainService = domainService; 
            _paymentEvent = paymentEvent;
        }

        public async Task<ReadPaymentDto<DebitCardDto>> AddAuthorizedAsync(PaymentInput<DebitCardDto> input)
        {
            var result = await _domainService.AddAuthorizedAsync(input.PaymentDto);
            await _paymentEvent.InvokeAuthorized(input.PaymentDto);

            return result;
        }

        public async Task<ReadPaymentDto<DebitCardDto>> AddUnauthorizedAsync(PaymentInput<DebitCardDto> input)
        {
            var result = await _domainService.AddUnauthorizedAsync(input.PaymentDto);
            await _paymentEvent.InvokeUnauthorized("Your payment has not been approved.", input.User.Email, input.PaymentDto);

            return result;
        }



        public async Task<ReadPaymentDto<DebitCardDto>> GetByIdAsync(Guid id)
        {
            var result = await _domainService.GetByIdAsync(id);
            return result;
        }

        public async Task<ReadPaymentDto<DebitCardDto>> GetByPurchaseIdAsync(int purchaseId)
        {
            var result = await _domainService.GetByPurchaseIdAsync(purchaseId);
            return result;
        }

        public async Task<IEnumerable<ReadPaymentDto<DebitCardDto>>> ListAsync()
        {
            var result = await _domainService.ListAsync();
            return result;
        }
    }
}