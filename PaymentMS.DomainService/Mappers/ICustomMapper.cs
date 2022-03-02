using PaymentMS.CrossCutting.Dtos;
using PaymentMS.Domain.Models.Entities;

namespace PaymentMS.DomainService.Mappers
{
    public interface ICustomMapper<TDto, TDomain> where TDomain : Payment where TDto : PaymentDto
    {
        TDomain Map(TDto payment);
        ReadPaymentDto<TDto> Map(TDomain payment);
        IList<ReadPaymentDto<TDto>> Map(IList<TDomain> payments);
    }
}