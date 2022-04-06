
using Microsoft.Extensions.Logging;
using NumberValidation.Validator.Validators.Interfaces;
using NumberValidation.Validator.ValidityChecks.Interfaces;

namespace NumberValidation.Validator.Validators;

public class CoOrdinationNumberValidator : Validator<ICoOrdinationNumberValidityCheck>, ICoOrdinationNumberValidator
{
    public CoOrdinationNumberValidator(ILogger<Validator<ICoOrdinationNumberValidityCheck>> logger) : base(logger)
    {
    }
}