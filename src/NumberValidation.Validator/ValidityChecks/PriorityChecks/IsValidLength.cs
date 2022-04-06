using NumberValidation.Validator.Models;
using NumberValidation.Validator.ValidityChecks.Interfaces;

namespace NumberValidation.Validator.ValidityChecks.PriorityChecks;

public class IsValidLength : ISocialSecurityValidityCheck, IOrganisationNumberValidityCheck, ICoOrdinationNumberValidityCheck, IPriorityValidityCheck
{
    public ValidationResult Validate(string number)
    {
        return new ValidationResult()
        {
            IsValid = ValidLengthSeparator(number) || ValidLength(number),
            Number = number
        };
    }

    private bool ValidLength(string number)
    {
        return !ContainsSeparator(number) && number.Length is 10 or 12;
    }

    private bool ValidLengthSeparator(string number)
    {
        return (ContainsSeparator(number)) && number.Length is 11 or 13;
    }

    private bool ContainsSeparator(string number)
    {
        return number.Contains("+") || number.Contains("-");
    }

    public string GetError(string number)
    {
        return $"{number} does not have a valid length!";
    }

    public int Priority => 1;
}