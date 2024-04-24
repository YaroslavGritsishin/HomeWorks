namespace Lecture_No30_HW.Models
{
    public class Contact
    {
        public int OfficeNumber { get; set; }
        public string City { get; set; }
        public Address Address { get; set; }
        public string  PhoneNumber { get; set; }

        public override string ToString()
            => $"{nameof(OfficeNumber)}: {OfficeNumber} " +
            $"{nameof(City)}: {City} " +
            $"{nameof(PhoneNumber)}: {PhoneNumber} " +
            $"{nameof(Address)}: {Address}";
    }
}
