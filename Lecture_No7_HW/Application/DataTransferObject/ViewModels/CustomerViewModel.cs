namespace Application.DataTransferObject.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public override string ToString() => $"Id : {Id}, Имя : {Firstname}, Фамилия : {Lastname}";
    }
}