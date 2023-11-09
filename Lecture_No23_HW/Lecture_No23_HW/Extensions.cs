namespace Lecture_No23_HW
{
    internal static class Extensions
    {
        public static async Task ExecuteInParallel<T>(this IEnumerable<T> source, Action<T> action)
        {
            List<Task> tasks = new();
            foreach (var item in source)
            {
                tasks.Add(Task.Run(() => action(item)));
            }
            await Task.WhenAll(tasks);
        }
        public static async Task<IEnumerable<T2>> ExecuteInParallel<T, T2>(this IEnumerable<T> source, Func<T, T2> func)
        {
            List<Task<T2>> tasks = new();
            foreach (var item in source)
            {
                tasks.Add(Task.Run(() => func(item)));
            }
            return await Task.WhenAll(tasks);
        }
    }
}
