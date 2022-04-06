using Microsoft.Extensions.DependencyInjection;
using NumberValidation.Validator.Services;
using NumberValidation.Validator.Validators;
using NumberValidation.Validator.Validators.Interfaces;

namespace NumberValidation.Validator;

public static class DependencyInjection
{
    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
        services.AddScoped<IValidationService, ValidationService>();

        services.AddScoped<ISocialSecurityNumberValidator, SocialSecurityNumberValidator>();
        services.AddScoped<ICoOrdinationNumberValidator, CoOrdinationNumberValidator>();
        services.AddScoped<IOrganisationNumberValidator, OrganisationNumberValidator>();

        return services;
    }
}