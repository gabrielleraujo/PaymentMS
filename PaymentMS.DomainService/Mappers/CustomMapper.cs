using AutoMapper;
using PaymentMS.CrossCutting.Dtos;
using PaymentMS.Domain.Models.Entities;

namespace PaymentMS.DomainService.Mappers
{
    public class CustomMapper<TDto, TDomain> : ICustomMapper<TDto, TDomain> where TDomain : Payment where TDto : PaymentDto
    {
        private readonly IMapper _mapper;
        public CustomMapper(IMapper mapper)
        {
            _mapper = mapper;
        }


        public TDomain Map(TDto payment)
        {
            var model = _mapper.Map<TDomain>(payment);
            return model;
        }

        public ReadPaymentDto<TDto> Map(TDomain payment)
        {
            var dto = new ReadPaymentDto<TDto>();
            var Tdto = _mapper.Map<TDto>(payment);
            dto.PaymentDto = Tdto;
            dto.Status = GetStateAsString(payment);
            return dto;
        }

        public IList<ReadPaymentDto<TDto>> Map(IList<TDomain> payments)
        {
            var dtos = new List<ReadPaymentDto<TDto>>();
            for (int i = 0; i < payments.Count; i++)
            {
                dtos.Add(Map(payments[i]));
            }
            return dtos;
        }

        public static string GetStateAsString(Payment model) => model.State.GetType().Name;
    }
}