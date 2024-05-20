using System.Reflection.Metadata.Ecma335;

namespace Lecture_No28_HW
{
    /// <summary>
    /// Математические расчёты
    /// </summary>
    public static class MathСalculation
    {
        private static Random random = new();
        /// <summary>
        /// Обычное вычисление суммы
        /// </summary>
        /// <param name="src">Исходные данные</param>
        /// <returns></returns>
        public static Task<int> SimpleCalculateSum(List<int> src) => Task.FromResult(src.Sum());
        /// <summary>
        /// Параллельное вычисление суммы с использованием Parallel LINQ.
        /// </summary>
        /// <param name="src">Исходные данные</param>
        /// <returns></returns>
        public static Task<int> LinqParallelCalculationSum(List<int> src) => Task.FromResult(src.AsParallel().Sum());
        /// <summary>
        /// Параллельное вычисление суммы с использованием пред выделенного пула Task.
        /// </summary>
        /// <param name="src">Исходные данные</param>
        /// <returns></returns>
        public static async Task<int> TasksParallelCalculationSum(List<int> src)
        {
            List<Task<int>> tasks = new();
            var processorCount = Environment.ProcessorCount;
            var takeRange = (int)Math.Ceiling(Convert.ToDecimal(src.Count()) / Convert.ToDecimal(processorCount));
            for(int i = 0; i < processorCount; i++)
            {
                int index = i;
                tasks.Add(Task.Run(() => src.GetRange(takeRange * index, takeRange).Sum()));
            }
            await Task.WhenAll(tasks);
            return tasks.Sum(t => t.Result);
        }
        /// <summary>
        /// Создаёт массив заполненный числовыми значениями в диапазоне от 1 до 1000
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <returns></returns>
        public static List<int> CreateFillArray(int size)
        {
            if (size == 0) return new();
            return Enumerable.Range(0, size)
                .Select(x => random.Next(1, 100))
                .ToList();
        }
    }
}