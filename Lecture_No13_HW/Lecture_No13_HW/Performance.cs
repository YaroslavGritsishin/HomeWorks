using System.Diagnostics;
using System.Text;

namespace Lecture_No13_HW
{
    public class Performance
    {
        static Stopwatch stopwatch = new();

        public static string? Serialize(ref StringBuilder sb, int iteration, Func<string> func)
        {
            var result = string.Empty;
            stopwatch.Start();
            foreach (var i in Enumerable.Range(1, iteration))
            {
                result = func?.Invoke();
            }
            stopwatch.Stop();
            sb.AppendLine($"[Время на сериализацию]: {stopwatch.Elapsed.ToString("ss\\.fff")} сек.");
            return result;
        }
        public static T? Deserialize<T>(ref StringBuilder sb, int iteration, Func<T> func)
        {
            T? result = default;
            stopwatch.Start();
            foreach (var i in Enumerable.Range(1, iteration))
            {
                result = func.Invoke();
            }
            stopwatch.Stop();
            sb.AppendLine($"[Время на десериализацию]: {stopwatch.Elapsed.ToString("ss\\.fff")} сек.");
            return result;
        }
    }
}
