using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Novafuria.DataIngester.Lifecycle.Temporalio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DemoController> _logger;

        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "RandomSummarie")]
        public String Get()
        {
            _logger.LogInformation("Getting random weather summary");

            Random random = new Random();
            return Summaries[random.Next(Summaries.Length)];
        }
    }
}
