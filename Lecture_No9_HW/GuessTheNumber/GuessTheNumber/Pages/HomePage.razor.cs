using BootstrapBlazor.Components;
using GuessTheNumber.Data.State;
using GuessTheNumber.Data.ViewModels;
using GuessTheNumber.Services.Abstractions;
using Microsoft.AspNetCore.Components;

namespace GuessTheNumber.Pages
{
    public partial class HomePage : ComponentBase, IDisposable
    {
        CancellationTokenSource cancellationTokenSource = new();
        [Inject] public ISettingViewModel SettingViewModel { get; set; }
        [Inject] public IMessageViewModel MessageViewModel { get; set; }
        [Inject] public IParameterCheckingService ParameterCheckingService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await SettingViewModel.InitializeAsync(cancellationTokenSource.Token);
            SettingViewModel.OnViewModelChanged += ViewModel_OnViewModelChanged;
            MessageViewModel.OnViewModelChanged += ViewModel_OnViewModelChanged;
            SettingViewModel.EnteredCount = default;
            MessageViewModel.ShowRulesOfTheGame();
        }

        private void ViewModel_OnViewModelChanged() =>
            StateHasChanged();

        public Circle Circle { get; set; } = new() { Color = Color.Primary };
        public int InputValue { get; set; }
        public bool IsDisabledInput { get; set; } = true;
        public bool IsShowSecretNumber { get; set; }
        public string SecretNumberStyle { get; set; } = string.Empty;

        public void OnStart()
        {
            IsDisabledInput = default;
            IsShowSecretNumber = default;
            ResetProgressBar();
            MessageViewModel.ShowInitialGreetingMessage();
            SettingViewModel.UpdateSecretNumber();
        }
        public Task OnValueChanged(int value)
        {
            UpdateProgressBar();
            PrintEnterNumber(value);
            if (SettingViewModel.SecretNumber.Equals(value))
            {
                IsShowSecretNumber = true;
                IsDisabledInput = true;
                SecretNumberStyle = "success";
                SuccessProgressBar();
                MessageViewModel.ShowWinningMessage();
                return Task.CompletedTask;
            }
            if (ParameterCheckingService.EqualsAttemptCount(SettingViewModel.EnteredCount))
            {
                IsShowSecretNumber = true;
                IsDisabledInput = true;
                SecretNumberStyle = "danger";
                DangerProgressBar();
                MessageViewModel.ShowGameOverMessage();
            }
            return Task.CompletedTask;
        }
        private void ResetInputValue() => InputValue = default;
        private void PrintEnterNumber(int number)
        {
            if (SettingViewModel.SecretNumber.Equals(number))
            {
                MessageViewModel.PrintMessage($"Вы ввели число {number} значение котогоро равно отгадываемому");
                return;
            }
            MessageViewModel.PrintMessage(ParameterCheckingService.IsMoreSecretNumber(number)
                ? $"Вы ввели число {number} значение котогоро больше отгадываемого"
                : $"Вы ввели число {number} значение котогоро меньше отгадываемого");
        }
        private void ResetProgressBar()
        {
            SettingViewModel.EnteredCount = default;
            Circle.Value = default;
            Circle.Color = Color.Primary;
        }
        private void UpdateProgressBar()
        {
            SettingViewModel.EnteredCount++;
            Circle.Value += ParameterCheckingService.EqualsAttemptCount(SettingViewModel.EnteredCount)
                ? 100 - Circle.Value
                : 100 / SettingViewModel.AttemptCount;
        }
        private void SuccessProgressBar()
        {
            Circle.Value = 100;
            Circle.Color = Color.Success;
        }
        private void DangerProgressBar()
        {
            Circle.Color = Color.Danger;
        }
        public void Dispose()
        {
            SettingViewModel.OnViewModelChanged -= ViewModel_OnViewModelChanged;
            MessageViewModel.OnViewModelChanged -= ViewModel_OnViewModelChanged;
            cancellationTokenSource.Cancel();
        }
    }
}
