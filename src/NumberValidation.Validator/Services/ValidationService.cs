using NumberValidation.Validator.Models;
using NumberValidation.Validator.Validators.Interfaces;

namespace NumberValidation.Validator.Services;

public class ValidationService : IValidationService
{
    private readonly ISocialSecurityNumberValidator _socialSecurityNumberValidator;
    private readonly ICoOrdinationNumberValidator _coOrdinationNumberValidator;
    private readonly IOrganisationNumberValidator _organisationNumberValidator;

    public ValidationService(
        ISocialSecurityNumberValidator socialSecurityNumberValidator, 
        ICoOrdinationNumberValidator coOrdinationNumberValidator, 
        IOrganisationNumberValidator organisationNumberValidator)
    {
        _socialSecurityNumberValidator = socialSecurityNumberValidator;
        _coOrdinationNumberValidator = coOrdinationNumberValidator;
        _organisationNumberValidator = organisationNumberValidator;
    }

    public ValidationSummary ValidateNumbers(IEnumerable<string> numbers)
    {
        var validationResult = new ValidationSummary();

        foreach (var number in numbers)
        {
            Validate(number, validationResult);
        }

        return validationResult;
    }

   

    private void Validate(string number, ValidationSummary validationresult)
    {
        if(ValidateSocialSecurityNumber(number))
            validationresult.AddValidSocialSecurityNumber(number);

        if (ValidateCoOrdinationNumber(number))
            validationresult.AddValidCoOrdninationNumber(number);

        if (ValidateOrganisationNumber(number))
            validationresult.AddValidOrganisationNumber(number);
    }

    private bool ValidateSocialSecurityNumber(string number)
    {
        var isValid = _socialSecurityNumberValidator.Validate(number);
        return isValid;
    }

    private bool ValidateCoOrdinationNumber(string number)
    {
        var isValid = _coOrdinationNumberValidator.Validate(number);
        return isValid;
    }

    private bool ValidateOrganisationNumber(string number)
    {
        var isValid = _organisationNumberValidator.Validate(number);
        return isValid;
    }


}
