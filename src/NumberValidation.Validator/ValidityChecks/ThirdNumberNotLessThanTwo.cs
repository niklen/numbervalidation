using NumberValidation.Validator.Models;
using NumberValidation.Validator.ValidityChecks.Interfaces;

namespace NumberValidation.Validator.ValidityChecks;

public class ThirdNumberNotLessThanTwo : IOrganisationNumberValidityCheck
{
    public ValidationResult Validate(string number)
    {
        var processnumber = number.Length > 11 ? number.Substring(2) : number;
        var third = processnumber[2].ToString();
        var thirdNumber = int.Parse(third);
        return new ValidationResult()
        {
            IsValid = thirdNumber >= 2,
            Number = number
        };
    }

    public string GetError(string number)
    {
        return $"---- Third digit in organisation number must be greater than one!";
    }
}