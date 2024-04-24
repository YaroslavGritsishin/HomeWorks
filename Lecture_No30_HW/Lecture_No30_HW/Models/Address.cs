namespace Lecture_No30_HW.Models
{
    public class Address
    {
        public int ZipCode { get; set; }
        public string Street { get; set; }
        public override string ToString() => $"{nameof(Street)}: {Street} " +
            $"{nameof(ZipCode)}: {ZipCode};";
    }
}
