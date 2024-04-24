using Lecture_No30_HW.Abstractions;

namespace Lecture_No30_HW.Models
{
    /// <summary>
    /// Контактная информация
    /// </summary>
    public class Contact : Address, IMyCloneable<Contact>
    {
        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        public Contact() { }
        public Contact(string city, string phoneNumber)
        {
            City = city;
            PhoneNumber = phoneNumber;
        }
        public Contact(Contact contact) : base(contact)
        {
            City = contact.City;
            PhoneNumber = contact.PhoneNumber;
        }
        public new Contact Copy() => new Contact(this);

        public override string ToString()
            => $"{nameof(City)}: {City}, " +
            $"{nameof(PhoneNumber)}: {PhoneNumber};";
    }
}
