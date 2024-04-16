using GuessTheNumber.Services.Abstractions;

namespace GuessTheNumber.Services
{
    public class GenerateNumberService : IGenerateNumberService
    {
        private readonly Random random = new Random();
        public Random Random => random;

        /// <summary>
        /// Создает случайно число в заданом диапазоне
        /// </summary>
        /// <param name="startRange">Начальное значение диапазона</param>
        /// <param name="endRange">Конечное значение диапазона</param>
        /// <returns>Случйное число в заданом диапазоне</returns>
        public int Generate(int startRange, int endRange) => Random.Next(startRange, endRange);

    }
}
