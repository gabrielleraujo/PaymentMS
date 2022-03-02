using PaymentMS.ApplicationService.Events.Interfaces;
using PaymentMS.CrossCutting.Dtos;
using PaymentMS.DomainService.Interfaces;

namespace PaymentMS.ApplicationService.Interfaces
{
    public class BoletoApplicationService<T> : IBoletoApplicationService<BoletoDto> where T : BoletoDto
    {
        private readonly IBoletoDomainService<BoletoDto> _domainService;
        private readonly IIssueInvoiceEvent _issueInvoiceEvent;

        public BoletoApplicationService(IBoletoDomainService<BoletoDto> domainService, IIssueInvoiceEvent issueInvoiceEvent)
        {
            _domainService = domainService;
            _issueInvoiceEvent = issueInvoiceEvent;
        }

        public async Task<ReadPaymentDto<BoletoDto>> AddAsync(PaymentInput<BoletoDto> input)
        {
            // aplicar descontos
            // salvar pagamento no banco de dados
            var result = await _domainService.AddAsync(input.PaymentDto);

            // emitir nota adicionando o frete e enviar para o email do cliente 
            await _issueInvoiceEvent.Generete(input.PaymentDto);

            return result;
        }



        public async Task<ReadPaymentDto<BoletoDto>> GetByIdAsync(Guid id)
        {
            var result = await _domainService.GetByIdAsync(id);
            return result;
        }

        public async Task<ReadPaymentDto<BoletoDto>> GetByPurchaseIdAsync(int purchaseId)
        {
            var result = await _domainService.GetByPurchaseIdAsync(purchaseId);
            return result;
        }

        public async Task<IEnumerable<ReadPaymentDto<BoletoDto>>> ListAsync()
        {
            var result = await _domainService.ListAsync();
            return result;
        }
    }
}