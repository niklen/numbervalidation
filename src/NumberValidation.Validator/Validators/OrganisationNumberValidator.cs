using Microsoft.Extensions.Logging;
using NumberValidation.Validator.Validators.Interfaces;
using NumberValidation.Validator.ValidityChecks.Interfaces;

namespace NumberValidation.Validator.Validators;

public class OrganisationNumberValidator : Validator<IOrganisationNumberValidityCheck>, IOrganisationNumberValidator
{
    public OrganisationNumberValidator(ILogger<Validator<IOrganisationNumberValidityCheck>> logger) : base(logger)
    {
    }
}