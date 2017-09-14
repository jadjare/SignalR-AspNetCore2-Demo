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
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IServiceProvider _serviceProvider;
        private IHubContext<DemoHub> _hubContext;

        public IndexModel(IServiceScopeFactory serviceScopeFactory, IServiceProvider serviceProvider)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _serviceProvider = serviceProvider;
        }

        public void OnGet()
        {
#pragma warning disable 4014
            BroadcastNewClientMessage();
#pragma warning restore 4014
        }

        public async Task BroadcastNewClientMessage()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var hubActivator = scope.ServiceProvider.GetRequiredService<IHubActivator<DemoHub>>();
                var hub = hubActivator.Create();
                if (_hubContext == null)
                    _hubContext = _serviceProvider.GetRequiredService<IHubContext<DemoHub>>();

                hub.Clients = _hubContext.Clients;

                await Task.Delay(20000);
                await hub.SendMessage($"New client calling. It's {DateTime.Now:f}");
            }


        }
    }
}
