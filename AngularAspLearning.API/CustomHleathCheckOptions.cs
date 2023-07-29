using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;
using System.Text.Json;

namespace AngularAspLearning.API
{
    public class CustomHleathCheckOptions: HealthCheckOptions
    {
        public CustomHleathCheckOptions() : base()
        {
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                WriteIndented= true,
            };

            ResponseWriter = async (context, request) =>
            {
                context.Response.ContentType = MediaTypeNames.Application.Json;
                context.Response.StatusCode = StatusCodes.Status200OK;

                var result = JsonSerializer.Serialize(new
                {
                    checks = request.Entries.Select(e => new
                    {
                        name = e.Key,
                        responseTime = e.Value.Duration.TotalMilliseconds,
                        status = e.Value.Status.ToString(),
                        description = e.Value.Description
                    }),
                    totalStatues = request.Status,
                    totalResponseTime = request.TotalDuration.TotalMilliseconds
                }, jsonSerializerOptions);

                await context.Response.WriteAsync(result);
            };
        }
    }
}
