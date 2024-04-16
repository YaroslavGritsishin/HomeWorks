using GuessTheNumber.Data.State;
using GuessTheNumber.Services.Abstractions;

namespace GuessTheNumber.Services
{
    public class ParameterCheckingService : IParameterCheckingService
    {
        private readonly ISettingViewModel settingViewModel;

        public ParameterCheckingService(ISettingViewModel settingViewModel) 
            => this.settingViewModel = settingViewModel;

        public bool EqualsAttemptCount(int currentCount) 
            => currentCount == settingViewModel.AttemptCount;

        public bool IsMoreSecretNumber(int number) 
            => number > settingViewModel.SecretNumber;

    }
}
