using AngularAspLearning.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace AngularAspLearning.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BroadcastController : ControllerBase
    {
        private readonly BroadcastService _broadcastService;

        public BroadcastController(BroadcastService broadcastService)
        {
            _broadcastService = broadcastService;
        }

        [HttpGet("startUpdates")]
        public async Task<IActionResult> StartUpdates()
        {
            await _broadcastService.StartUpdates();
            return Ok("started");
        }

        [HttpGet("stopUpdates")]
        public IActionResult StopUpdates()
        {
            _broadcastService.StopUpdates();
            return Ok("stopped");
        }
    }
}
