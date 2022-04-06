
using NumberValidation.Validator.Models;

namespace NumberValidation.API.Contracts;

public class ValidateResponse
{
    public ValidationSummary Summary { get; set; }
}