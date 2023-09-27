using Lecture_No17_HW_Core;

CancellationTokenSource tokenSource = new CancellationTokenSource();
using PathFinder pathFinder = new PathFinder();
pathFinder.Subscribe(args => Console.WriteLine(args.FileName));
pathFinder.Execute("D:\\Tests", tokenSource.Token);
Console.ReadLine();



