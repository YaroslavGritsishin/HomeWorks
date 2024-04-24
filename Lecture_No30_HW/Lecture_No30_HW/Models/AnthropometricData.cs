using Lecture_No30_HW.Abstractions;

namespace Lecture_No30_HW.Models
{
    /// <summary>
    /// Aнтропометрические данные 
    /// </summary>
    public class AnthropometricData : IMyCloneable<AnthropometricData>, ICloneable
    {
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }

        public AnthropometricData() { }
        public AnthropometricData(double height, double weight)
        {
            Height = height;
            Weight = weight;
        }
        public AnthropometricData(AnthropometricData anthropometric)
        {
            Height = anthropometric.Height;
            Weight = anthropometric.Weight;
        }

        public AnthropometricData Copy() => new AnthropometricData(this);

        public object Clone() => MemberwiseClone();
        public override string ToString()=> $"{nameof(Height)}: {Height}м,\r\n" +
            $"{nameof(Weight)}: {Weight}кг;";

    }
}
