using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Scrolling.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Scrolling.Server.Controllers
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

        private List<WeatherForecast> list = new List<WeatherForecast>();
        

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(new WeatherForecast() { TemperatureC = i });
            }
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return list.ToArray();
        }


        [HttpGet("{skip}/{count}")]
        public IEnumerable<WeatherForecast> Get(int skip, int count)
        {
            return list.ToArray().Skip(skip).Take(count);
        }
    }
}
