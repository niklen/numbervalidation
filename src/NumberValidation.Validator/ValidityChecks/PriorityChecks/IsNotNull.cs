using NumberValidation.Validator.Models;
using NumberValidation.Validator.ValidityChecks.Interfaces;

namespace NumberValidation.Validator.ValidityChecks.PriorityChecks;

public class IsNotNull : ISocialSecurityValidityCheck, ICoOrdinationNumberValidityCheck, IOrganisationNumberValidityCheck, IPriorityValidityCheck
{
    public string GetError(string number)
    {
        return $"---- Number cannot be null!";
    }

    public ValidationResult Validate(string number)
    {
        return new ValidationResult
        {
            IsValid = !string.IsNullOrEmpty(number),
            Number = number
        };
    }

    public int Priority => 0;
}