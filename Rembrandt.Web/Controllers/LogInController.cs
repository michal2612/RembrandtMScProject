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
                Response.Cookies.Append("jwtToken", "asdjksajdk2ewkjksac");
            }
            catch(Exception e)
            {
                return RedirectToAction("Register", "Users", new RegisterViewModel() {RegisterData = register.RegisterData, ExceptionMessage = e.Message});
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            try
            {
                Response.Cookies.Delete("jwtToken");
            }
            catch {}
            return RedirectToAction("Index", "Home");
        }
    }
}