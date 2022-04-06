using Microsoft.Extensions.Logging;
using NumberValidation.Validator.Validators.Interfaces;
using NumberValidation.Validator.ValidityChecks.Interfaces;

namespace NumberValidation.Validator.Validators;

public class SocialSecurityNumberValidator : Validator<ISocialSecurityValidityCheck>, ISocialSecurityNumberValidator
{
    public SocialSecurityNumberValidator(ILogger<Validator<ISocialSecurityValidityCheck>> logger) : base(logger)
    {
    }
}