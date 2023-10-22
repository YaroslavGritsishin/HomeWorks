namespace Application.Errors
{
    public class CustomerNotFoundExeption: Exception
    {
        public CustomerNotFoundExeption(string message) : base(message) { }
    }
}
