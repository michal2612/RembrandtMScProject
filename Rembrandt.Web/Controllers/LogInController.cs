using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rembrandt.Web.Controllers
{
    [Route("[action]")]
    public class LogInController : Controller
    {
        readonly ILogger<LogInController> _logger;

        public LogInController(ILogger<LogInController> logger)
        {
            _logger = logger;
        }

        public IActionResult Register()
            => View();

        public IActionResult Login()
            => View();
    }
}