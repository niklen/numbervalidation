using NumberValidation.Validator.Models;
using NumberValidation.Validator.ValidityChecks.Interfaces;

namespace NumberValidation.Validator.ValidityChecks;

public class IsValidBirthdateSocialSecurityNumber : ISocialSecurityValidityCheck
{
    public ValidationResult Validate(string number)
    {
        var result = new ValidationResult
        {
            IsValid = ValidateBirthdate(number),
            Number = number
        };

        return result;
    }

    private bool ValidateBirthdate(string inputnumber)
    {
        var number = inputnumber.Length > 11 ? inputnumber.Substring(2) : inputnumber;
        return ValidateYear(number) && ValidateMonth(number, out var month) && ValidateDay(number, month);
    }

    private static bool ValidateDay(string number, int month)
    {
        var birthday = number.Substring(4, 2);

        if (!int.TryParse(birthday, out var day)) 
            return false;

        if (day < 0)
            return false;
        
        if (month is 2 && day > 28)
            return false;

        if (month is 1 or 3 or 5 or 7 or 8 or 10 or 12 && day > 31)
            return false;

        if (day > 30)
            return false;
        
        return true;
    }

    private static bool ValidateMonth(string number, out int month)
    {
        var birthmonth = number.Substring(2, 2);

        if (!int.TryParse(birthmonth, out month)) 
            return false;
       
        if (month is > 12 or < 0)
            return false;

        return true;

    }

    private static bool ValidateYear(string number)
    {

        var birthyear = number.Substring(0, 2);
        
        if (!int.TryParse(birthyear, out _))
            return false;
        
        return true;
    }

    public string GetError(string number) => $"---- {number} does not contain a valid birthdate!";

}