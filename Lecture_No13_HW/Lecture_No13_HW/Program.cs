using Lecture_No13_HW;
using System.Text;
using System.Text.Json;

StringBuilder sb = new();
var csvSerializeResult = string.Empty;
var jsonSerializeResult = string.Empty;
int iterationNumber = 100000;

F TestClassF = new()
{
    i1 = 1,
    i2 = 2,
    i3 = 3,
    i4 = 4,
    i5 = 5
};


sb.AppendLine("[Мой рефлекшен]:");
csvSerializeResult = Performance.Serialize(ref sb, iterationNumber, () => ReflectionSerializer.Serialize(TestClassF));
var csvDeserializationResult = Performance.Deserialize(ref sb, iterationNumber, () => ReflectionSerializer.Deserialize<F>(csvSerializeResult));

sb.AppendLine("[Cтандартный механизм (System.Text.Json.JsonSerializer)]:");
jsonSerializeResult = Performance.Serialize(ref sb, iterationNumber, () => JsonSerializer.Serialize(TestClassF, new JsonSerializerOptions() { IncludeFields = true }));
Performance.Deserialize(ref sb, iterationNumber, () => JsonSerializer.Deserialize<F>(jsonSerializeResult));

sb.Insert(0, $"[Количество замеров]: {iterationNumber} итераций \r\n");
sb.Insert(0, $"[Код десериализации из CSV]: {csvDeserializationResult}\r\n");
sb.Insert(0, $"[Код сериализации в CSV]: {csvSerializeResult} \r\n");
sb.Insert(0, $"[Сериализуемый класс]: {ReflectionSerializer.ShowClassFields(TestClassF)} \r\n");
Console.WriteLine(sb.ToString());

Console.ReadKey();