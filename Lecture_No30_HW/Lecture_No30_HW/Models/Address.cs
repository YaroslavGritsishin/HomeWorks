using Lecture_No30_HW.Abstractions;

namespace Lecture_No30_HW.Models
{
    /// <summary>
    /// Адресс
    /// </summary>
    public class Address : IMyCloneable<Address>
    {
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public int ZipCode { get; set; }
        /// <summary>
        /// Название улицы
        /// </summary>
        public string Street { get; set; }

        public Address() { }
        public Address(int zipCode, string street)
        {
            ZipCode = zipCode;
            Street = street;
        }
        public Address(Address address)
        {
            ZipCode = address.ZipCode;
            Street = address.Street;
        }
        public Address Copy() => new Address(this);

        public override string ToString() => $"{nameof(Street)}: {Street} " +
            $"{nameof(ZipCode)}: {ZipCode};";
    }
}
