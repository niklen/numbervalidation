using NumberValidation.Validator.Models;
using NumberValidation.Validator.ValidityChecks.Interfaces;

namespace NumberValidation.Validator.ValidityChecks.PriorityChecks;

public class IsNumber : ISocialSecurityValidityCheck, IOrganisationNumberValidityCheck, ICoOrdinationNumberValidityCheck, IPriorityValidityCheck
{
    public ValidationResult Validate(string number)
    {
        var isValid = false;
        var removedSeparator = string.Join(string.Empty,number.Split('+', '-'));
        
        if (long.TryParse(removedSeparator, out _))
            isValid = true;

        return new ValidationResult()
        {
            IsValid = isValid,
            Number = number
        };
    }

    public string GetError(string number)
    {
        return $"{number} is not a number!";
    }

    public int Priority => 2;
}