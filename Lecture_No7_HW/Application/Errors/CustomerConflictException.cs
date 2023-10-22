namespace Application.Errors
{
    public class CustomerConflictException: Exception
    {
        public CustomerConflictException(string message): base(message)
        {
            
        }
    }
}
