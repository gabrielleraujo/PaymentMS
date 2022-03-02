using Microsoft.AspNetCore.Mvc;
using PaymentMS.ApplicationService.Interfaces;
using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/payment/boleto")]
    public class BoletoController : ControllerBase
    {
        private readonly IBoletoApplicationService<BoletoDto> _boletoApplicationService;

        public BoletoController(IBoletoApplicationService<BoletoDto> paymentApplicationService) 
        {
            _boletoApplicationService = paymentApplicationService;
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] PaymentInput<BoletoDto> paymentInputData)
        {
            var result = await _boletoApplicationService.AddAsync(paymentInputData);
            return Ok(result);
        }



        [HttpGet("list")]
        public async Task<IActionResult> ListAsync()
        {
            var result = await _boletoApplicationService.ListAsync();
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _boletoApplicationService.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("purchase/{id:int}")]
        public async Task<IActionResult> GetByPurchaseIdAsync(int id)
        {
            var result = await _boletoApplicationService.GetByPurchaseIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }
    }
}