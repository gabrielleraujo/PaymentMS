using AutoMapper;
using PaymentMS.CrossCutting.Dtos;
using PaymentMS.Domain.Models.Entities;

namespace PaymentMS.Infrastructure.Profiles
{
    public class PaymentModelToPaymentDto : Profile
    {
        public PaymentModelToPaymentDto()
        {
            CreateMap<CreditCard, CreditCardDto>();
            CreateMap<DebitCard, DebitCardDto>();
            CreateMap<Boleto, BoletoDto>();
        }
    }
}