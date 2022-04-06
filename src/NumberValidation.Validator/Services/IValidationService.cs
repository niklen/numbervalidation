using NumberValidation.Validator.Models;

namespace NumberValidation.Validator.Services;

public interface IValidationService
{
    ValidationSummary ValidateNumbers(IEnumerable<string> numbers);
}