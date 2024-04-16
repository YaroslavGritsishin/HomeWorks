using GuessTheNumber.Data.Repositories.Abstraction;
using GuessTheNumber.Services.Abstractions;
using MvvmHelpers;
using System.Runtime.CompilerServices;

namespace GuessTheNumber.Data.State
{
    public class SettingViewModel : BaseViewModel, ISettingViewModel
    {
        private readonly ISettingRepository settingRepository;
        private readonly IGenerateNumberService generateNumberService;
        public SettingViewModel(ISettingRepository settingRepository, IGenerateNumberService generateNumberService)
        {
            this.settingRepository = settingRepository;
            this.generateNumberService = generateNumberService;
        }

        private Guid id = Guid.Empty;
        private int attemptCount, startRange, endRange,
            enteredCount, secretNumber = default;
        public Guid Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public int AttemptCount
        {
            get => attemptCount;
            set => SetProperty(ref attemptCount, value);
        }
        public int EnteredCount
        {
            get => enteredCount;
            set => SetProperty(ref enteredCount, value);
        }
        public int StartRange
        {
            get => startRange;
            set => SetProperty(ref startRange, value);
        }
        public int EndRange
        {
            get => endRange;
            set => SetProperty(ref endRange, value);
        }
        public int SecretNumber
        {
            get => secretNumber;
            set => SetProperty(ref secretNumber, value);
        }

        public async Task InitializeAsync(CancellationToken cancellationToken)
        {
            if (Id == Guid.Empty)
            {
                var settings = (await settingRepository.GetAsync(cancellationToken))?.FirstOrDefault();
                if (settings is null) return;
                Id = settings.Id;
                StartRange = settings.StartRange;
                EndRange = settings.EndRange;
                AttemptCount = settings.AttemptCount;
                EnteredCount = default;
                UpdateSecretNumber();
            }
        }
        public void UpdateSecretNumber() => SecretNumber = generateNumberService.Generate(StartRange, EndRange);

        public event Action OnViewModelChanged;
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.OnPropertyChanged(propertyName);
            OnViewModelChanged?.Invoke();
        }
    }
    public interface ISettingViewModel
    {
        Guid Id { get; set; }
        /// <summary>
        /// Количество попыток отгадывания числа
        /// </summary>
        int AttemptCount { get; set; }
        /// <summary>
        /// Значение введенных попыток 
        /// </summary>
        int EnteredCount { get; set; }
        /// <summary>
        /// Начальное значение диапазона для случайного числа
        /// </summary>
        int StartRange { get; set; }
        /// <summary>
        /// Конечное значение диапазона для случайного числа
        /// </summary>
        int EndRange { get; set; }
        /// <summary>
        /// Секретрное число
        /// </summary>
        int SecretNumber { get; set; }

        Task InitializeAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Обновляет секретное число
        /// </summary>
        void UpdateSecretNumber();

        event Action OnViewModelChanged;
    }
}
