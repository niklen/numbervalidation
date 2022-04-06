using NumberValidation.Validator.Models;
using NumberValidation.Validator.ValidityChecks.Interfaces;

namespace NumberValidation.Validator.ValidityChecks;

public class IsLuhnsValid : ISocialSecurityValidityCheck, ICoOrdinationNumberValidityCheck, IOrganisationNumberValidityCheck 
{
    public ValidationResult Validate(string inputnumber)
    {
        var sum = 0;

        var processnumber = string.Join(string.Empty,inputnumber.Split('+', '-'));

        processnumber = inputnumber.Length is 12 or 13 ?
            processnumber.Substring(2) :
            processnumber;

        for (var i = 0; i < processnumber.Length - 1; i++)
        {
            var number = int.Parse(processnumber[i].ToString());
            
            if (i % 2 == 0)
                number *= 2;

            var first = 0;
            var second = 0;

            if (number > 9)
            {
                first = number / 10;
                second = number % 10;
            }
            else
            {
                first = number;
            }

            sum += (first + second);
        }

        sum = (10 - sum % 10) % 10;

        var checknumber = int.Parse(processnumber[^1].ToString());

        return new ValidationResult
        {
            IsValid = sum == checknumber, 
            Number = inputnumber
        };

    }

    public string GetError(string number) => $"---- {number} is not valid according to Luhns algoritm!";
}