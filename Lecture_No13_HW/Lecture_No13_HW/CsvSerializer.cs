using System.Reflection;
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
    }
}
