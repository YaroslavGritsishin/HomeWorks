using Lecture_No28_HW;
using System.Text;

StringBuilder sb = new();
var SizeS = MathСalculation.CreateFillArray(100000);
var SizeM = MathСalculation.CreateFillArray(1000000);
var SizeL = MathСalculation.CreateFillArray(10000000);

await Perfomance.ExecuteAllMethodsOfSumAsync(sb, SizeS);
await Perfomance.ExecuteAllMethodsOfSumAsync(sb, SizeM);
await Perfomance.ExecuteAllMethodsOfSumAsync(sb, SizeL);

Console.WriteLine(sb);
Console.ReadKey();