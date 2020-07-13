using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rembrandt.Contracts.Classes.User;
using Rembrandt.Users.Infrastructure.Services.Users;
using Rembrandt.Web.ViewModels;
using System.Web;

namespace Rembrandt.Web.Controllers
{
    [Route("[action]")]
    public class LogInController : Controller
    {
        private readonly ILogger<LogInController> _logger;

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