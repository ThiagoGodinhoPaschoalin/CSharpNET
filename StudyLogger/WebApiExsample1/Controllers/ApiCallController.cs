using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiMVC_Example1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCallController : ControllerBase
    {
        private readonly ILogger _logger;

        public ApiCallController(ILogger<ApiCallController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Check()
        {
            using( _logger.BeginScope("Checking {ControllerName}", typeof(ApiCallController)))
            {
                _logger.LogWarning("Sample!");
                return Ok(DateTime.UtcNow);
            }
        }
    }
}