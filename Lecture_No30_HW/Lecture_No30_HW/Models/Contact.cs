namespace Lecture_No30_HW.Models
{
    /// <summary>
    /// Контактная информация
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public Address Address { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string  PhoneNumber { get; set; }

        public override string ToString()
            => $"{nameof(City)}: {City} " +
            $"{nameof(PhoneNumber)}: {PhoneNumber} " +
            $"{nameof(Address)}: {Address}";
    }
}
