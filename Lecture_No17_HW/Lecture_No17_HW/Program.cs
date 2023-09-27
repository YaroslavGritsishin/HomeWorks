using Lecture_No17_HW_Core;
using Lecture_No17_HW_Core.Models;


CancellationTokenSource tokenSource = new CancellationTokenSource();
string directoryPath = "D:\\Tests";
using PathFinder pathFinder = new PathFinder();
Console.WriteLine("Subscribe to FindPath event");
pathFinder.Subscribe(args => Console.WriteLine($"Найден файл ${args.FileName}"));
Console.WriteLine($"Start find file of {directoryPath} directory!");
pathFinder.Execute(directoryPath, tokenSource.Token);
Console.WriteLine("End find File!");
Console.WriteLine($"Return Start faind file of {directoryPath} directory!");
pathFinder.Execute(directoryPath, tokenSource.Token);
Console.WriteLine("End find File!");
Console.WriteLine("Cancel publish events!");
tokenSource.Cancel();
Console.WriteLine($"Return Start faind file of {directoryPath} directory!");
pathFinder.Execute(directoryPath, tokenSource.Token);
Console.WriteLine("End find File!");
Console.WriteLine("Program is finished!");
Console.ReadLine();



