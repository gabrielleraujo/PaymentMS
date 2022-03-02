using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.DomainService.Interfaces
{
    public interface IBoletoDomainService<T> : IPaymentDomainService<T> where T : BoletoDto
    {
        Task<ReadPaymentDto<BoletoDto>> AddAsync(BoletoDto paymentDto);
    }
}