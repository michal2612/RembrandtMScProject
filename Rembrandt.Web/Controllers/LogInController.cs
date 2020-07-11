using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rembrandt.Contracts.Classes.User;
using Rembrandt.Users.Infrastructure.Services.Users;
using Rembrandt.Web.ViewModels;

namespace Rembrandt.Web.Controllers
{
    public class LogInController : Controller
    {
        private readonly ILogger<LogInController> _logger;

        public LogInController(ILogger<LogInController> logger)
        {
            _logger = logger;
        }

        public IActionResult Register(RegisterViewModel register)
        {
            try
            {
                Int32.Parse(register.Register.RepeatPassword);
            }
            catch(Exception e)
            {
                return RedirectToAction("Register", "Users", new RegisterViewModel() {Register = register.Register, ExceptionMessage = e.Message});
            }
            return Content("hehe");
        }
    }
}