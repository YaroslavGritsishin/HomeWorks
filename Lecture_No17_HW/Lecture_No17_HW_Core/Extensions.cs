using System.Runtime.CompilerServices;

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
        public static PathFinder Subscribe(this PathFinder pathFinder, PathFinder.EventHandler handler) 
        {
            pathFinder.FileFound += handler;
            return pathFinder;
        }
        public static PathFinder Unsubscribe(this PathFinder pathFinder, PathFinder.EventHandler handler) 
        {
            pathFinder.FileFound -= handler;
            return pathFinder;
        }
    }
}

