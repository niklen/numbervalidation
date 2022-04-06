using NumberValidation.Validator.Models;
using NumberValidation.Validator.ValidityChecks.Interfaces;

namespace NumberValidation.Validator.ValidityChecks.PriorityChecks;

public class ValidSeparator : ISocialSecurityValidityCheck, IOrganisationNumberValidityCheck, ICoOrdinationNumberValidityCheck, IPriorityValidityCheck
{
    private static readonly List<char> ValidSeparators = new(){'-', '+'};

    public ValidationResult Validate(string number)
    {
        var isOk = true;
        
        if (number.Length is 11 or 13)
            isOk = ValidSeparators.Contains(number[^5]);

        return new ValidationResult()
        {
            IsValid = isOk,
            Number = number
        };
    }


    public string GetError(string number)
    {
        return $"{number} contains a separator that is not valid!";
    }

    public int Priority => 3;
}