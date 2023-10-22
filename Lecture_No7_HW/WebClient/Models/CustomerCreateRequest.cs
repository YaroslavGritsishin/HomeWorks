namespace WebClient.Models
{
    public class CustomerCreateRequest
    {
        public CustomerCreateRequest()
        {
        }

        public CustomerCreateRequest(
            string firstName,
            string lastName)
        {
            Firstname = firstName;
            Lastname = lastName;
        }

        public string Firstname { get; init; }

        public string Lastname { get; init; }
        public override string ToString() => $"Имя: {Firstname}, Фамилия: {Lastname}";

    }
}