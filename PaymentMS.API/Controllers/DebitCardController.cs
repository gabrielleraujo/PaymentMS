using Microsoft.AspNetCore.Mvc;
using PaymentMS.ApplicationService.Interfaces;
using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/payment/debitCard")]
    public class DebitCardController : ControllerBase
    {
        IDebitCardApplicationService<DebitCardDto> _debitCardApplicationService;

        public DebitCardController(IDebitCardApplicationService<DebitCardDto> paymentApplicationService) 
        {
            _debitCardApplicationService = paymentApplicationService;
        }


        [HttpPost("Authorized")]
        public async Task<IActionResult> AddAuthorizedAsync([FromBody] PaymentInput<DebitCardDto> paymentInputData)
        {
            var result = await _debitCardApplicationService.AddAuthorizedAsync(paymentInputData);
            return Ok(result);
        }

        [HttpPost("Unauthorized")]
        public async Task<IActionResult> AddUnauthorizedAsync([FromBody] PaymentInput<DebitCardDto> paymentInputData)
        {
            var result = await _debitCardApplicationService.AddUnauthorizedAsync(paymentInputData);
            return Ok(result);
        }



        [HttpGet("list")]
        public async Task<IActionResult> ListAsync()
        {
            var result = await _debitCardApplicationService.ListAsync();
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _debitCardApplicationService.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("purchase/{id:int}")]
        public async Task<IActionResult> GetByPurchaseIdAsync(int id)
        {
            var result = await _debitCardApplicationService.GetByPurchaseIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }
    }
}