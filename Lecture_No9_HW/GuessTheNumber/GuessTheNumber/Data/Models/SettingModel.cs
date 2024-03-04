using GuessTheNumber.Data.Models.Abstract;

namespace GuessTheNumber.Data.Models
{
    public class SettingModel: IBaseEntity
    {
        public Guid Id { get; set; }
        public int AttemptsNumber { get; set; }
        public int StartRange { get; set; }
        public int EndRange { get; set; }
    }
}
