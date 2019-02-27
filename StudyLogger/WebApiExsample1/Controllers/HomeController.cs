using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiMVC_Example1.Models;

namespace WebApiMVC_Example1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogDebug(Logging.LoggingEvents.HomeShowIndexPage, "## Open index page");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogDebug(Logging.LoggingEvents.HomeShowPrivacyPage, "## Open privacy page");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogDebug(Logging.LoggingEvents.HomeShowErrorPage, "## Open error page");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
