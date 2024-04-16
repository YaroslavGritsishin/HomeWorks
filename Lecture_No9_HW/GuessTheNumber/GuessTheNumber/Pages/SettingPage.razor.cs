using GuessTheNumber.Data.Models;
using GuessTheNumber.Data.Repositories.Abstraction;
using GuessTheNumber.Data.State;
using Microsoft.AspNetCore.Components;

namespace GuessTheNumber.Pages
{
    public partial class SettingPage : ComponentBase, IDisposable
    {
        private CancellationTokenSource cancellationTokenSource = new();
        [Inject] public ISettingRepository SettingRepository { get; set; }
        [Inject] public ISettingViewModel SettingViewModel { get; set; }

        public async void OnSave()
        {
            await SettingRepository.UpdateAsync(new SettingModel()
            {
                Id = SettingViewModel.Id,
                StartRange = SettingViewModel.StartRange,
                EndRange = SettingViewModel.EndRange,
                AttemptCount = SettingViewModel.AttemptCount
            }, cancellationTokenSource.Token);
        }

        public void Dispose()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
