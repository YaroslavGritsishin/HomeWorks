using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;

namespace GuessTheNumber.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        public List<MenuItem> Items { get; set; } = new();
        protected override void OnInitialized()
        {
            Items.Add(new MenuItem() { Text = "Главная", Url = "/" });
            Items.Add(new MenuItem() { Text = "Настройки", Url = "Settings" });
        }
    }
}
