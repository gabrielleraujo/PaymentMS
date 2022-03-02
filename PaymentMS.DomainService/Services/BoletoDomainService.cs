using PaymentMS.CrossCutting.Dtos;
using PaymentMS.Domain.Models.Entities;
using PaymentMS.DomainService.Mappers;
using PaymentMS.Infrastructure.Data.Repository;

namespace PaymentMS.DomainService.Interfaces
{
    public class BoletoDomainService<T> : IBoletoDomainService<BoletoDto> where T : BoletoDto
    {
        private readonly IPaymentRepository<Boleto> _repository;
        private readonly ICustomMapper<BoletoDto, Boleto> _mapper;

        public BoletoDomainService(IPaymentRepository<Boleto> repository, ICustomMapper<BoletoDto, Boleto> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReadPaymentDto<BoletoDto>> AddAsync(BoletoDto paymentDto)
        {
            var entity = _mapper.Map(paymentDto);

            entity.ApplyDiscount();
            entity.AuthorizedPayment();

            await _repository.AddAsync(entity);
            await _repository.Commit();

            return _mapper.Map(entity);
        }

        public async Task<ReadPaymentDto<BoletoDto>> GetByIdAsync(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            return _mapper.Map(result);
        }

        public async Task<ReadPaymentDto<BoletoDto>> GetByPurchaseIdAsync(int purchaseId)
        {
            var result = await _repository.GetAsync(x => x.PurchaseId == purchaseId);
            return _mapper.Map(result);
        }

        public async Task<IEnumerable<ReadPaymentDto<BoletoDto>>> ListAsync()
        {
            var result = await _repository.ListAsync();
            return _mapper.Map(result);
        }
    }
}