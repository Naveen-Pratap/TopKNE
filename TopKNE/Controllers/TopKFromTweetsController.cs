using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TopKNE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopKFromTweetsController : ControllerBase
    {

        private readonly ILogger<TopKFromTweetsController> _logger;
        private readonly ITwitterService _service;

        public TopKFromTweetsController(ITwitterService service)
        {
            _service = service;
        }
        public TopKFromTweetsController(ILogger<TopKFromTweetsController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
