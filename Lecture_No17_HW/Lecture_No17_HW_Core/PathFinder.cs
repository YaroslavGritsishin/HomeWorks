using Lecture_No17_HW_Core.Models;

namespace Lecture_No17_HW_Core
{
    public class PathFinder: IDisposable
    {
        public delegate void EventHandler(FileArgs args);
        public event EventHandler FileFound;

        public void Execute(string directoryName)
        {
            Directory.GetFiles(directoryName)
                .ToList()
                .ForEach(filePath => FileFound?.Invoke(new FileArgs() { FileName = $"Found file: {Path.GetFileName(filePath)}"}));
        }

        public void Dispose()
        {
            foreach (EventHandler method in FileFound.GetInvocationList())
            {
                FileFound -= method;
            }
        }
    }
}
