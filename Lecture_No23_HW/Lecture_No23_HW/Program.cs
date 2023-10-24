using System.Diagnostics;

internal class Program
{
    public static async Task Main(string[] args)
    {
        Stopwatch stopWatch = new();
        List<Task> tasks = new();
        
        stopWatch.Start();
        
        foreach (var filePath in Directory.GetFiles("FILES_OTUS_HW"))
            tasks.Add(Task.Run(() => ReadAndCountSpases(filePath))); 

        await Task.WhenAll(tasks);
        
        stopWatch.Stop();

        await Console.Out.WriteLineAsync(stopWatch.Elapsed.ToString(@"m\:ss\.ffff"));
        Console.ReadLine();
    }
    public static void ReadAndCountSpases(string filePath)
    {
        var count = File.ReadAllText(filePath).Count(symbol => symbol == ' ');
        Console.WriteLine($"File with name: {Path.GetFileName(filePath)} contains {count} spaces");
    }


}