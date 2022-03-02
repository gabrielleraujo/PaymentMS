using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.ApplicationService.Interfaces
{
    public interface IBoletoApplicationService<T> : IPaymentApplicationService<T> where T : BoletoDto
    {
        Task<ReadPaymentDto<BoletoDto>> AddAsync(PaymentInput<T> paymentDto);
    }
}