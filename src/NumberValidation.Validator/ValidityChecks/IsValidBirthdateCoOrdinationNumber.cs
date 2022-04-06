using NumberValidation.Validator.Models;
using NumberValidation.Validator.ValidityChecks.Interfaces;

namespace NumberValidation.Validator.ValidityChecks;

public class IsValidBirthdateCoOrdinationNumber : ICoOrdinationNumberValidityCheck
{
    public ValidationResult Validate(string number)
    {
        var convertedNumber = ConvertToSocialSecurityNumberFormat(number);
        
        return new ValidationResult
        {
            IsValid = new IsValidBirthdateSocialSecurityNumber().Validate(convertedNumber).IsValid,
            Number = convertedNumber
        };
    }

    private string ConvertToSocialSecurityNumberFormat(string inputnumber)
    {
        var number = inputnumber.Length > 11 ? inputnumber.Substring(2) : inputnumber;
        var year = number.Substring(0, 2);
        var month = number.Substring(2, 2);
        var birthday = number.Substring(4, 2);
        var birthnumber = number.Substring(6);
        
        var actualBirthday = int.Parse(birthday) - 60;
        return $"{year}{month}{actualBirthday}{birthnumber}";
    }

    public string GetError(string number) => $"---- {number} does not contain a valid birthdate!";
}