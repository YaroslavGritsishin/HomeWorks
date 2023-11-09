using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObject.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }

        public override string ToString() => $"Id : {Id}, Имя : {Firstname}, Фамилия : {Lastname}";
    }
}