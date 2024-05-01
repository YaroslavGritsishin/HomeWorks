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
        public static Task<int> SimpleCalculateSum(int[] src) => Task.FromResult(src.Sum());
        /// <summary>
        /// Параллельное вычисление суммы с использовнием Parallel LINQ.
        /// </summary>
        /// <param name="src">Исходные данные</param>
        /// <returns></returns>
        public static Task<int> LinqParallelCalculationSum(int[] src) => Task.FromResult(src.AsParallel().Sum());
        /// <summary>
        /// Параллельное вычисление суммы с использовнием предвыделенного пула Task.
        /// </summary>
        /// <param name="src">Исходные данные</param>
        /// <returns></returns>
        public static async Task<int> TasksParallelCalculationSum(int[] src)
        {
            List<Task<int>> tasks = new();
            var processorCount = Environment.ProcessorCount;
            var takeRange = (int)Math.Ceiling(Convert.ToDecimal(src.Count()) / Convert.ToDecimal(processorCount));
            for(int i = 0; i < processorCount - 1; i++)
            {
                tasks.Add(Task.Run(() => src.Skip(takeRange * index).Take(takeRange).Sum()));
            }
            await Task.WhenAll(tasks);
            return tasks.Sum(t => t.Result);
        }
        /// <summary>
        /// Создает массив заполненный числовыми значениями в диапазоне от 1 до 1000
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <returns></returns>
        public static int[] CreateFillArray(int size)
        {
            if (size == 0) return Array.Empty<int>();
            return Enumerable.Range(0, size)
                .Select(x => random.Next(1, 100))
                .ToArray();
        }
    }
}