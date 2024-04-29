using System.Diagnostics;
using System.Text;

namespace Lecture_No28_HW
{
    public static class Perfomance
    {

        private static readonly Stopwatch sw = new();

        public static async Task<int> ExecuteAsync(StringBuilder sb, Func<Task<int>> func)
        {
            sw.Restart();
            var result = await func.Invoke();
            sw.Stop();
            sb.Append($" {result} \r\n");
            sb.AppendLine($"[Время выполнения]: {sw.Elapsed.ToString("ss\\.fff")} сек.");
            return result;
        }

        /// <summary>
        /// Выполняет замеры производительности расчета суммы для заданого массива интов, тримя способами (Обычным, параллельным с использованием Task, параллельным с помощью LINQ)
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="src">Исходные данные</param>
        /// <returns></returns>
        public static async Task ExecuteAllMethodsOfSumAsync(StringBuilder sb, int[] src)
        {
            sb.AppendLine($"[Размер массива данных {src.Count()}]");
            sb.Append("[Расчёт суммы массива обычным методом]:");
            await ExecuteAsync(sb, () => MathСalculation.SimpleCalculateSum(src));
            sb.Append("[Расчёт суммы массива c использовнием Parallel LINQ]:");
            await ExecuteAsync(sb, () => MathСalculation.LinqParallelCalculationSum(src));
            sb.Append("[Расчёт суммы массива c использовнием предвыделенного пула Task]:");
            await ExecuteAsync(sb, () => MathСalculation.TasksParallelCalculationSum(src));
            sb.AppendLine();
        }
    }
}
