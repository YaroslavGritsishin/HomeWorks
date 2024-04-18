using Lecture_No13_HW;
using System.Text.Json;

F TestClassF = new()
{
    i1 = 1,
    i2 = 2,
    i3 = 3,
    i4 = 4,
    i5 = 5
};

var csv = CsvSerializer.Serializer(TestClassF);
Console.WriteLine($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {csv}");

var js = JsonSerializer.Serialize(TestClassF, new JsonSerializerOptions() { IncludeFields = true});
Console.WriteLine($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] {js}");

Console.ReadKey();