using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rembrandt.Contracts.Classes.User;
using Rembrandt.Users.Infrastructure.Services;
using Rembrandt.Web.ViewModels;

namespace Rembrandt.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        public  IActionResult Login(Login login)
        {
            return View();
        }

        public IActionResult Register(RegisterViewModel register)
        {
            return View(register);
        }
    }
}