using AutoMapper;
using PaymentMS.CrossCutting.Dtos;
using PaymentMS.Domain.Models.Entities;
using PaymentMS.Domain.Models.States;

namespace PaymentMS.Infrastructure.Profiles
{
    public class PaymentDtoToPaymentModel : Profile
    {
        public PaymentDtoToPaymentModel()
        {
            CreateMap<CreditCardDto, CreditCard>()
                .ConstructUsing(x => new CreditCard(
                    new Guid(), x.Number, x.Agency, x.NumberInstallments, x.NumberInstallmentsPaid, x.InstallmentValue, x.TotalInterest,
                    x.PurchaseId, new PaymentValidationState()));

            CreateMap<DebitCardDto, DebitCard>()
                .ConstructUsing(x => new DebitCard(
                    new Guid(), x.Number, x.Agency,
                    x.PurchaseId, new PaymentValidationState()));

            CreateMap<BoletoDto, Boleto>()
                .ConstructUsing(x => new Boleto(
                    new Guid(), x.BarCode, x.DueDate,
                    x.PurchaseId, new PaymentValidationState()));


            CreateMap<ReadPaymentDto<CreditCardDto>, CreditCard>()
                .ConstructUsing(x => new CreditCard(
                    new Guid(), x.PaymentDto.Number, x.PaymentDto.Agency, x.PaymentDto.NumberInstallments, x.PaymentDto.NumberInstallmentsPaid, x.PaymentDto.InstallmentValue, x.PaymentDto.TotalInterest,
                    x.PaymentDto.PurchaseId, new PaymentValidationState()));

            CreateMap<ReadPaymentDto<DebitCardDto>, DebitCard>()
                .ConstructUsing(x => new DebitCard(
                    new Guid(), x.PaymentDto.Number, x.PaymentDto.Agency,
                    x.PaymentDto.PurchaseId, new PaymentValidationState()));

            CreateMap<ReadPaymentDto<BoletoDto>, Boleto>()
                .ConstructUsing(x => new Boleto(
                    new Guid(), x.PaymentDto.BarCode, x.PaymentDto.DueDate,
                    x.PaymentDto.PurchaseId, new PaymentValidationState()));
        }
    }
}