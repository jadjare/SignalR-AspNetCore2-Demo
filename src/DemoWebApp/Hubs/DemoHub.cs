using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace DemoWebApp.Hubs
{
    public class DemoHub: Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.InvokeAsync("MessageSent", message);
        }

    }
}
