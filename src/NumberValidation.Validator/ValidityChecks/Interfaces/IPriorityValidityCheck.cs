namespace NumberValidation.Validator.ValidityChecks.Interfaces;

public interface IPriorityValidityCheck : IValidityCheck
{
    int Priority { get; }
}