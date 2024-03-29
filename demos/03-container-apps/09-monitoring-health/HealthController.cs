using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConfigApi
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {        

        IConfiguration cfg;
        ILogger<HealthController> logger;
        private static List<string> logs = new List<string>();

        public HealthController(IConfiguration config, ILogger<HealthController> log)
        {
            cfg=config;
            logger=log;
        }

        private void LogProbe(string message)
        {
            Console.WriteLine("Health Controller: " + message);
            logger.LogInformation(message);
        }

        // http://localhost:PORT/health/liveness
        [HttpGet("liveness")]
        public IActionResult GetLiveness()
        {
            LogProbe($"{DateTime.UtcNow} -- Liveness {logs.Count}");
            if (logs.Count <= 10)
                return Ok();
            else
                return BadRequest();
        }

        // http://localhost:PORT/health/readiness
        [HttpGet("readiness")]
        public IActionResult GetReadiness()
        {
            LogProbe($"{DateTime.UtcNow} -- Readiness {logs.Count}");
            return Ok();
        }

        // http://localhost:PORT/health/startup
        [HttpGet("startup")]
        public IActionResult GetStartup()
        {
            LogProbe($"{DateTime.UtcNow} -- Startup {logs.Count}");
            return Ok();
        }
    }
}