using AngularAspLearning.API.Controllers;
using Microsoft.AspNetCore.SignalR;
using System.Timers;
using Timer = System.Timers.Timer;

namespace AngularAspLearning.API.Services
{
    public class BroadcastService
    {
        private readonly IHubContext<HealthCheckHub> _hubContext;
        private readonly ILogger<BroadcastService> _logger;

        private Timer _timer;

        public BroadcastService(
            IHubContext<HealthCheckHub> hubContext,
            ILogger<BroadcastService> logger
        )
        {
            _timer = new Timer(1000);
            _timer.Elapsed += async (sender, e) => await SendUpdates(sender, e);
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task StartUpdates()
        {
            _timer.Start();
        }

        public void StopUpdates()
        {
            _timer.Stop();
        }

        private async Task SendUpdates(object sender, ElapsedEventArgs e)
        {
            // Generate or fetch the data to send to the client
            DateTime data = DateTime.Now;
            _logger.LogInformation("Sending data to clients: " + data);
            await _hubContext.Clients.All.SendAsync("Update", data);
        }
    }
}
