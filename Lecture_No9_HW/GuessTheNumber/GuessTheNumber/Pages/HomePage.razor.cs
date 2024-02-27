using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;

namespace GuessTheNumber.Pages
{
    public partial class HomePage : ComponentBase
    {
        public List<ConsoleMessageItem> Messages { get; set; } = new List<ConsoleMessageItem>() 
        {
            new ConsoleMessageItem(){Message=$"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] Привет"}
        };
        public int BindValue { get; set; }
        public void OnClear() => Messages.Clear();
        public Task OnValueChanged(int value)
        {
            BindValue = value;
            Messages.Add(new ConsoleMessageItem() { Message = $"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] Вы ввели число {value}" });
            StateHasChanged();
            return Task.CompletedTask;
        }
    }
}
