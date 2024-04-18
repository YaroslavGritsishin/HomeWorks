using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Lecture_No13_HW
{
    public class CsvSerializer
    {
        public static string Serializer(object obj)
        {
            Type serializationObjectType = obj.GetType();
            FieldInfo[] fields = serializationObjectType.GetFields();
            return string.Join(',', fields.Select(f => f.GetValue(obj)));
        }
        public static TValue? Deserialize<TValue>(object obj)
        {
            var destinationInstance = Activator.CreateInstance(typeof(TValue));
            Type srcType = obj.GetType();
            if (obj is string inputValue)
            {
                var fields = destinationInstance?.GetType().GetFields();
                if (fields is null) return default;
                foreach (var (index, value) in inputValue.Split(",").Select((value, index) => (index, value)))
                {
                    if (index > fields.Length - 1) break;
                    fields[index].SetValue(destinationInstance, string.IsNullOrEmpty(value) ? default : int.Parse(value));
                }
            }
            return (TValue?)destinationInstance;
        }
    }
}
