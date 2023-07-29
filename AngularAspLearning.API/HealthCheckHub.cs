using Microsoft.AspNetCore.SignalR;
using System.Timers;

namespace AngularAspLearning.API
{
    public class HealthCheckHub : Hub
    {
        public async Task Update(string data)
        {
            Console.WriteLine("recieved from client: " + data);
            await Clients.All.SendAsync("Update", "this is healthcheck data");
        }
    }
}
