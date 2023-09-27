namespace Lecture_No17_HW_Core
{
    public static class Extensions
    {
        public static T GetMax<T>(this IEnumerable<T> e, Func<T, float> getParameter) where T : class
        {
            Dictionary<float, T> result = new();
            foreach (var item in e) 
                result[getParameter(item)] = item;
            return result[result.Keys.Max()];
        }
    }
}
