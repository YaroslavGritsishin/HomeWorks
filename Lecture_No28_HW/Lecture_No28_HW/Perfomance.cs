using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace Lecture_No28_HW
{
    public static class Perfomance
    {

        private static readonly Stopwatch sw = new();

        public static void Execute(ref StringBuilder sb, Func<int> func)
        {
            sw.Start();
            var result = func?.Invoke();
            sw.Stop();
            sb.Append($" {result} \r\n");
            sb.AppendLine($"[Время выполнения]: {sw.Elapsed.ToString("ss\\.fff")} сек.");
        }
    }
}
