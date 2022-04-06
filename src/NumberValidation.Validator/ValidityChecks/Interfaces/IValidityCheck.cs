using NumberValidation.Validator.Models;

namespace NumberValidation.Validator.ValidityChecks.Interfaces;

public interface IValidityCheck
{
    ValidationResult Validate(string number);
    string GetError(string number);
}