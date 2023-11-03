using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloDeanDotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZodiacForecastController : ControllerBase
    {
        private static readonly string[] ZodiacSigns = new[]
        {
            "aries", "taurus", "gemini", "cancer", "leo", "virgo", "libra", "scorpio", "sagittarius", "capricorn", "aquarius", "pisces" 
        };

        private readonly ILogger<ZodiacForecastController> _logger;

        public ZodiacForecastController(ILogger<ZodiacForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ZodiacForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ZodiacForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = ZodiacSigns[rng.Next(ZodiacSigns.Length)]
            })
            .ToArray();
        }
    }
}
