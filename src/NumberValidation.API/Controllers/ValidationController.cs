using Microsoft.AspNetCore.Mvc;
using NumberValidation.API.Contracts;
using NumberValidation.Validator.Services;

namespace NumberValidation.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ValidationController : ControllerBase
    {

        private readonly ILogger<ValidationController> _logger;
        private readonly IValidationService _validationService;

        public ValidationController(ILogger<ValidationController> logger, IValidationService validationService)
        {
            _logger = logger;
            _validationService = validationService;
        }

        [HttpPost]
        public ActionResult<ValidateResponse> Validate(ValidateRequest request)
        {

            var result = _validationService.ValidateNumbers(request.Numbers);
            return new ValidateResponse
            {
                Summary = result
            };
        }
    }
}