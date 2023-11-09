namespace Application.DataTransferObject.ViewModels
{
    public class ValidationResult
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public Errors Errors { get; set; }
    }

    public class Errors
    {
        public string[] Lastname { get; set; }
        public string[] Firstname { get; set; }
    }


}
