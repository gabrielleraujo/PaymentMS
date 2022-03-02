using Microsoft.AspNetCore.Mvc;
using PaymentMS.ApplicationService.Interfaces;
using PaymentMS.CrossCutting.Dtos;

namespace PaymentMS.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/payment/creditCard")]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardApplicationService<CreditCardDto> _creditCardApplicationService;

        public CreditCardController(ICreditCardApplicationService<CreditCardDto> paymentApplicationService) 
        {
            _creditCardApplicationService = paymentApplicationService;
        }


        [HttpPost("Authorized")]
        public async Task<IActionResult> AddAuthorizedAsync([FromBody] PaymentInput<CreditCardDto> paymentInputData)
        {
            var result = await _creditCardApplicationService.AddAuthorizedAsync(paymentInputData);
            return Ok(result);
        }

        [HttpPost("Unauthorized")]
        public async Task<IActionResult> AddUnauthorizedAsync([FromBody] PaymentInput<CreditCardDto> paymentInputData)
        {
            var result = await _creditCardApplicationService.AddUnauthorizedAsync(paymentInputData);
            return Ok(result);
        }



        [HttpGet("list")]
        public async Task<IActionResult> ListAsync()
        {
            var result = await _creditCardApplicationService.ListAsync();
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _creditCardApplicationService.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("purchase/{id:int}")]
        public async Task<IActionResult> GetByPurchaseIdAsync(int id)
        {
            var result = await _creditCardApplicationService.GetByPurchaseIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }
    }
}