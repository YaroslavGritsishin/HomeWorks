using GuessTheNumber.Data.Models;
using GuessTheNumber.Data.Repositories.Abstraction;

namespace GuessTheNumber.Data.Repositories
{
    public class SettingRepository : Repository<SettingModel>, ISettingRepository
    {
        public SettingRepository(ApplicationContext context) : base(context) { }
    }
}
