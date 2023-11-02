using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi_JWT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin, Support")]     //  Authentication
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            // User Identity
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = identity?.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value
                          //Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}