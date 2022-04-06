using Microsoft.Extensions.Logging;
using NumberValidation.Validator.Validators.Interfaces;
using NumberValidation.Validator.ValidityChecks.Interfaces;

namespace NumberValidation.Validator.Validators;

public abstract class Validator<T> : IValidator where T : IValidityCheck
{
    private readonly ILogger<Validator<T>> _logger;
    private List<IValidityCheck> _validityChecks;
    private List<IPriorityValidityCheck> _priorityChecks;

    protected Validator(ILogger<Validator<T>> logger)
    {
        _logger = logger;
        InitializeValidityChecks();
    }

    private void InitializeValidityChecks()
    {
        var type = typeof(T);

        var validityChecks = GetType().Assembly.GetTypes()
            .Where(t => type.IsAssignableFrom(t) && !t.IsInterface)
            .Select(r => Activator.CreateInstance(r) as IValidityCheck);

        var prioritychecks = validityChecks
            .OfType<IPriorityValidityCheck>()
            .ToList();

        _validityChecks = validityChecks
            .Where(vc => vc is not IPriorityValidityCheck)
            .ToList();

        _priorityChecks = prioritychecks;
    }


    private bool ExecuteValidityCheck(IValidityCheck check, string number)
    {
        try
        {
            var result = check.Validate(number);

            if (!result.IsValid)
            {
                _logger.LogError($"{check.GetError(number)} ({GetType().Name})");
                return false;
            }

            number = result.Number;
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"---- Could not execute validation for {check.GetType()}!");
            return false;
        }
    }

    public bool Validate(string number)
    {

        foreach (var priorityValidityCheck in _priorityChecks.OrderBy(p => p.Priority))
        {
            if(!ExecuteValidityCheck(priorityValidityCheck, number))
                return false;
        }

        foreach (var validityCheck in _validityChecks)
        {
            if (!ExecuteValidityCheck(validityCheck, number))
                return false;
        }
        
        _logger.LogInformation($"---- {number} is a valid number! ({GetType().Name})");
        return true;
    }
}