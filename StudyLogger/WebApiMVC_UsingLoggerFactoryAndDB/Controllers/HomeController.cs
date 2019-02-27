using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApiMVC_UsingLoggerFactoryAndDB.Models;
using WebApiMVC_UsingLoggerFactoryAndDB.Repository;

namespace WebApiMVC_UsingLoggerFactoryAndDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly LogEventRepository _logger;

        public HomeController(LogEventRepository logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.Log(Microsoft.Extensions.Logging.LogLevel.Critical, Models.Enum.LogType.OpenHomeIndex, "Entrando na tela principal!");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.Log(Microsoft.Extensions.Logging.LogLevel.Critical, Models.Enum.LogType.OpenHomePrivacy, "Entrando na tela de privacidade!");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
