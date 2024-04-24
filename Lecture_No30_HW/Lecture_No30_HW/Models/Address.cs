namespace Lecture_No30_HW.Models
{
    /// <summary>
    /// Адресс
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public int ZipCode { get; set; }
        /// <summary>
        /// Название улицы
        /// </summary>
        public string Street { get; set; }
        public override string ToString() => $"{nameof(Street)}: {Street} " +
            $"{nameof(ZipCode)}: {ZipCode};";
    }
}
