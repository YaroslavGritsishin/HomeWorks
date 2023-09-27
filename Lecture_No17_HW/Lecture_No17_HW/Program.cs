using Lecture_No17_HW_Core;
using Lecture_No17_HW_Core.Models;

CancellationTokenSource tokenSource = new CancellationTokenSource();
using PathFinder pathFinder = new PathFinder();
pathFinder.Subscribe(args => Console.WriteLine(args.FileName));
pathFinder.Execute("D:\\Tests");
Console.ReadLine();



