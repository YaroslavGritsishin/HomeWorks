using GuessTheNumber.Data.Models.Abstract;

namespace GuessTheNumber.Data.Models
{
    public class SettingModel : IBaseEntity
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Количество попыток отгадывания числа
        /// </summary>
        public int AttemptCount { get; set; }
        /// <summary>
        /// Начальное значение диапазона для случайного числа
        /// </summary>
        public int StartRange { get; set; }
        /// <summary>
        /// Конечное значение диапазона для случайного числа
        /// </summary>
        public int EndRange { get; set; }
    }
}
