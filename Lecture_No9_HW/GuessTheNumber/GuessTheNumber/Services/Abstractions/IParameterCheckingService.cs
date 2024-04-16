using Microsoft.AspNetCore.DataProtection;

namespace GuessTheNumber.Services.Abstractions
{
    public interface IParameterCheckingService
    {
        bool IsMoreSecretNumber(int number);
        bool EqualsAttemptCount(int currentCount);
    }
}
