using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutorizeCode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiTwo.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet]

        [Procedure("FRM:VAC","Edit")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [Procedure("FRM:VAC", "Add")]
        [HttpPost("Insert")]
        public IActionResult Post()
        {
            return Ok("Todo Bien con Post");
        }
        [Procedure("FRMEMP", "View")]
        [HttpPut("Update")]
        public IActionResult Put() => Ok("Todo Bien con Put");
    }
}
