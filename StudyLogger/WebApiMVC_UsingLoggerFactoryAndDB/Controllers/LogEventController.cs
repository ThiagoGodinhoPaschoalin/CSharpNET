using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiMVC_UsingLoggerFactoryAndDB.Repository;

namespace WebApiMVC_UsingLoggerFactoryAndDB.Controllers
{
    public class LogEventController : Controller
    {
        private readonly LogEventRepository _logger;

        public LogEventController(LogEventRepository logEvent)
        {
            _logger = logEvent;
        }

        // GET: LogEvent
        public async Task<IActionResult> Index()
        {
            return View(await _logger.GetAllLogs());
        }
    }
}
