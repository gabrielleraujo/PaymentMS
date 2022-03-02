using PaymentMS.CrossCutting.Dtos;
using PaymentMS.Domain.Models.Entities;
using PaymentMS.DomainService.Mappers;
using PaymentMS.Infrastructure.Data.Repository;

namespace PaymentMS.DomainService.Interfaces
{
    public class DebitCardDomainService<T> : IDebitCardDomainService<DebitCardDto> where T : DebitCardDto
    {
        private readonly IPaymentRepository<DebitCard> _repository;
        private readonly ICustomMapper<DebitCardDto, DebitCard> _mapper;

        public DebitCardDomainService(IPaymentRepository<DebitCard> repository, ICustomMapper<DebitCardDto, DebitCard> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<ReadPaymentDto<DebitCardDto>> AddAuthorizedAsync(DebitCardDto paymentDto)
        {
            var entity = _mapper.Map(paymentDto);
            entity.AuthorizedPayment();
            await _repository.AddAsync(entity);

            return _mapper.Map(entity);
        }

        public async Task<ReadPaymentDto<DebitCardDto>> AddUnauthorizedAsync(DebitCardDto paymentDto)
        {
            var entity = _mapper.Map(paymentDto);
            entity.UnauthorizedPayment();
            await _repository.AddAsync(entity);

            return _mapper.Map(entity);
        }



        public async Task<ReadPaymentDto<DebitCardDto>> GetByIdAsync(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            return _mapper.Map(result);
        }

        public async Task<ReadPaymentDto<DebitCardDto>> GetByPurchaseIdAsync(int purchaseId)
        {
            var result = await _repository.GetAsync(x => x.PurchaseId == purchaseId);
            return _mapper.Map(result);
        }

        public async Task<IEnumerable<ReadPaymentDto<DebitCardDto>>> ListAsync()
        {
            var result = await _repository.ListAsync();
            return _mapper.Map(result);
        }
    }
}