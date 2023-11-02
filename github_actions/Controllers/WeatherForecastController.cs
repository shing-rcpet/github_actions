using Microsoft.AspNetCore.Mvc;

namespace github_actions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "冰封的", "清新的", "寒冷的", "凉爽的", "温和的", "温暖的", "温和宜人的", "酷热的", "酷热难耐的", "灼热的"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                MyName = "My name2 is " + Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}