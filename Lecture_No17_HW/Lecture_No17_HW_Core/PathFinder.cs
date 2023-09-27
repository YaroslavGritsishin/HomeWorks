using Lecture_No17_HW_Core.Models;

namespace Lecture_No17_HW_Core
{
    public class PathFinder: IDisposable
    {
        public delegate void EventHandler(FileArgs args);
        public event EventHandler FileFound;

        public void Execute(string directoryName, CancellationToken token)
        {
            var result = Directory.GetFiles(directoryName).ToList();
                result.ForEach(filePath => {
                    if (!token.IsCancellationRequested)
                        FileFound?.Invoke(new FileArgs() { FileName = $"Found file: {Path.GetFileName(filePath)}" });   
                });
            if(!token.IsCancellationRequested)
                Console.WriteLine($"Самое длиное навание файла: {result.GetMax(path => (float)path.Length)}");
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
