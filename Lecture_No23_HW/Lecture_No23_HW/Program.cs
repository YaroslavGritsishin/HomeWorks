using Lecture_No23_HW;
using Lecture_No23_HW.Models;
using System.Diagnostics;

internal class Program
{
    public static async Task Main(string[] args)
    {
        Stopwatch stopWatch = new();
        string directoryPath = "FILES_OTUS_HW";

        stopWatch.Start();

        await ParallelReadAndCountSpacesInFilesOfDirectory(directoryPath);
         
        stopWatch.Stop();

        await Console.Out.WriteLineAsync(stopWatch.Elapsed.ToString(@"m\:ss\.ffff"));
        Console.ReadLine();
    }
    public static void CountSpases(FileData fileData)
    {
        var count = fileData.Data?.Count(symbol => symbol == ' ');
        Console.WriteLine($"File with name: {Path.GetFileName(fileData.FilePath)} contains {count} spaces");
    }
    public static FileData ReadFile(string filePath) => new FileData()
    {
        Data = File.ReadAllText(filePath),
        FilePath = filePath
    };
    public static async Task ParallelReadAndCountSpacesInFilesOfDirectory(string dictionaryPath)
    {
        var filesPath = Directory.GetFiles(dictionaryPath);
        var readFilesData = await filesPath.ExecuteInParallel(ReadFile);
        await readFilesData.ExecuteInParallel(CountSpases);
    }
}