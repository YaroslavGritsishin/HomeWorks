// See https://aka.ms/new-console-template for more information
using Lecture_No28_HW;
using System.Text;

StringBuilder sb = new();
var SizeS = MathСalculation.CreateFillArray(100000);
var SizeM = MathСalculation.CreateFillArray(1000000);
var SizeL = MathСalculation.CreateFillArray(10000000);

sb.AppendLine("[Размер массива данных 100000]");
sb.Append("[Расчёт суммы массива обычным методом]:");
Perfomance.Execute(ref sb, () => MathСalculation.SimpleCalculateSum(SizeS));
sb.Append("[Расчёт суммы массива c использовнием Parallel LINQ]:");
Perfomance.Execute(ref sb, () => MathСalculation.LinqParallelCalculationSum(SizeS));
sb.Append("[Расчёт суммы массива c использовнием предвыделенного пула Task]:");
Perfomance.Execute(ref sb, () => MathСalculation.TasksParallelCalculationSum(SizeS).Result);
sb.AppendLine();

sb.AppendLine("[Размер массива данных 1000000]");
sb.Append("[Расчёт суммы массива обычным методом]:");
Perfomance.Execute(ref sb, () => MathСalculation.SimpleCalculateSum(SizeM));
sb.Append("[Расчёт суммы массива c использовнием Parallel LINQ]:");
Perfomance.Execute(ref sb, () => MathСalculation.LinqParallelCalculationSum(SizeM));
sb.Append("[Расчёт суммы массива c использовнием предвыделенного пула Task]:");
Perfomance.Execute(ref sb, () => MathСalculation.TasksParallelCalculationSum(SizeM).Result);
sb.AppendLine();

sb.AppendLine("[Размер массива данных 10000000]");
sb.Append("[Расчёт суммы массива обычным методом]:");
Perfomance.Execute(ref sb, () => MathСalculation.SimpleCalculateSum(SizeL));
sb.Append("[Расчёт суммы массива c использовнием Parallel LINQ]:");
Perfomance.Execute(ref sb, () => MathСalculation.LinqParallelCalculationSum(SizeL));
sb.Append("[Расчёт суммы массива c использовнием предвыделенного пула Task]:");
Perfomance.Execute(ref sb, () => MathСalculation.TasksParallelCalculationSum(SizeL).Result);

Console.WriteLine(sb);
Console.ReadKey();