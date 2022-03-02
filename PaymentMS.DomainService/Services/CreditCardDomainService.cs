using PaymentMS.CrossCutting.Dtos;
using PaymentMS.Domain.Models.Entities;
using PaymentMS.DomainService.Mappers;
using PaymentMS.Infrastructure.Data.Repository;

namespace PaymentMS.DomainService.Interfaces
{
    public class CreditCardDomainService<T> : ICreditCardDomainService<CreditCardDto> where T : CreditCardDto
    {
        private readonly IPaymentRepository<CreditCard> _repository;
        private readonly ICustomMapper<CreditCardDto, CreditCard> _mapper;

        public CreditCardDomainService(IPaymentRepository<CreditCard> repository, ICustomMapper<CreditCardDto, CreditCard> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<ReadPaymentDto<CreditCardDto>> AddAuthorizedAsync(CreditCardDto paymentDto)
        {
            var entity = _mapper.Map(paymentDto);
            entity.AuthorizedPayment();
            await _repository.AddAsync(entity);

            return _mapper.Map(entity);
        }

        public async Task<ReadPaymentDto<CreditCardDto>> AddUnauthorizedAsync(CreditCardDto paymentDto)
        {
            var entity = _mapper.Map(paymentDto);
            entity.UnauthorizedPayment();
            await _repository.AddAsync(entity);

            return _mapper.Map(entity);
        }



        public async Task<ReadPaymentDto<CreditCardDto>> GetByIdAsync(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            return _mapper.Map(result);
        }

        public async Task<ReadPaymentDto<CreditCardDto>> GetByPurchaseIdAsync(int purchaseId)
        {
            var result = await _repository.GetAsync(x => x.PurchaseId == purchaseId);
            return _mapper.Map(result);
        }

        public async Task<IEnumerable<ReadPaymentDto<CreditCardDto>>> ListAsync()
        {
            var result = await _repository.ListAsync();
            return _mapper.Map(result);
        }
    }
}