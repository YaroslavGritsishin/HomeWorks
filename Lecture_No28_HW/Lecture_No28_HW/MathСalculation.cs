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
            foreach (var data in PreparingData(src))
            {
                tasks.Add(Task.Run(() => data.Sum()));
            }
            await Task.WhenAll(tasks);
            return tasks.Sum(t => t.Result);
        }
        /// <summary>
        /// Разбивает данные на части в соответствии количеству ядер используемого процессора
        /// </summary>
        /// <param name="src">Исходные данные</param>
        /// <returns></returns>
        private static IEnumerable<IEnumerable<int>> PreparingData(int[] src)
        {
            List<IEnumerable<int>> result = new();
            var processorCount = Environment.ProcessorCount;
            var takeRange = (int) Math.Ceiling( Convert.ToDecimal(src.Count()) / Convert.ToDecimal(processorCount));
            Enumerable.Range(0, Environment.ProcessorCount).ToList().ForEach(index =>
            {
                result.Add(src.Skip(takeRange * index).Take(takeRange));
            });
            return result;
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