using BootstrapBlazor.Components;
using GuessTheNumber.Data.State;
using MvvmHelpers;
using System.Runtime.CompilerServices;

namespace GuessTheNumber.Data.ViewModels
{
    public class MessageViewModel : BaseViewModel, IMessageViewModel
    {
        private ISettingViewModel settings;
        public MessageViewModel(ISettingViewModel settings)
        {
            this.settings = settings;
        }
        public ObservableRangeCollection<ConsoleMessageItem> Messages { get; set; } = new();
        public event Action OnViewModelChanged;
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.OnPropertyChanged(propertyName);
            OnViewModelChanged?.Invoke();
        }
        public void ShowRulesOfTheGame()
        {
            Messages.Clear();
            Messages.Add(new ConsoleMessageItem() { Message = $"Доброго времени суток!" });
            Messages.Add(new ConsoleMessageItem() { Message = $"Перед началом игры \"Угадай Число!\" давайте ознакомимся с правилами:" });
            Messages.Add(new ConsoleMessageItem() { Message = $"1. Колличество попыток ограничено значением {settings.AttemptCount}" });
            Messages.Add(new ConsoleMessageItem() { Message = $"2. Загаданое число находится в диапазоне от {settings.StartRange} до {settings.EndRange}" });
            Messages.Add(new ConsoleMessageItem() { Message = $"Диапазон и значение количества попыток Вы можете задать самостоятельно перейдя на вкладку \"Настройки\"" });
            Messages.Add(new ConsoleMessageItem() { Message = $"После каждого ввода ответа мы будем Вас информировать о результатах его проверки (значени было больше, меньше или равно отгадываемого)" });
            Messages.Add(new ConsoleMessageItem() { Message = $"Ввести вариант ответа Вы можете в поле \"Введите число\" ниже окна уведомлений" });
        }
        public void ShowInitialGreetingMessage()
        {
            Messages.Clear();
            Messages.Add(new ConsoleMessageItem() { Message = "Игра Началась!" });
            Messages.Add(new ConsoleMessageItem() { Message = "Мы загадали число, попробуйте его отгадать." });
        }
        public void ShowGameOverMessage() => Messages.Add(new ConsoleMessageItem()
        {
            Message = "К сожалению Вы проиграли. Закончилось количество попыток, спасибо за участие!",
            Color = Color.Danger
        });
        public void ShowWinningMessage() => Messages.Add(new ConsoleMessageItem()
        {
            Message = $"Поздровляем у Вас получилось отгадать число!",
            Color= Color.Success
        });

        public void PrintMessage(string msg) => Messages.Add(new ConsoleMessageItem()
        {
            Message = $"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {msg}"
        });
    }

    public interface IMessageViewModel
    {
        /// <summary>
        /// Событие информирующие о изменении модели данных
        /// </summary>
        event Action OnViewModelChanged;
        /// <summary>
        /// Список сообщений для вывода на консоль 
        /// </summary>
        ObservableRangeCollection<ConsoleMessageItem> Messages { get; set; }
        /// <summary>
        /// Выводит на консоль информацию о настройках
        /// </summary>
        void ShowRulesOfTheGame();
        /// <summary>
        /// Приветствие в начале игры
        /// </summary>
        void ShowInitialGreetingMessage();
        /// <summary>
        /// Сообщение о неудачном окончании игры
        /// </summary>
        void ShowGameOverMessage();
        /// <summary>
        /// Сообщение о победе в игре 
        /// </summary>
        void ShowWinningMessage();
        /// <summary>
        /// Вывести сообщение
        /// </summary>
        /// <param name="msg">Текст сообщения</param>
        void PrintMessage(string msg);
    }
}
