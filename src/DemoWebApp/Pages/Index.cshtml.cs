using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApp.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace DemoWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHubContext<DemoHub> _demoHubContext;

        public IndexModel(IHubContext<DemoHub> demoHubContext)
        {
            _demoHubContext = demoHubContext;
        }

        public void OnGet()
        {
#pragma warning disable 4014
            BroadcastNewClientMessage();
#pragma warning restore 4014
        }

        public async Task BroadcastNewClientMessage()
        {
            await Task.Delay(5000);
            await _demoHubContext.Clients.All.InvokeAsync("messageSent", $"New client calling. It's {DateTime.Now:f}"); //See advice here, https://github.com/aspnet/SignalR/issues/182, with regard to creating a common hub methods implementation.  To keep things simple this advice isn't implemented here
        }
    }
}
