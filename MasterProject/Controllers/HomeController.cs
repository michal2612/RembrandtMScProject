using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MasterProject.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MasterProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try {
                if (!String.IsNullOrWhiteSpace(Request.Cookies["username"].ToString()))
                    return View();
            }
            catch (Exception) { 
            }
            return View("IndexNotLogged");
        }
        //[Authorize]
        public IActionResult Privacy()
        {
            return Content("Dupa");
        }

        //TEST ONLY
        public void GenerateToken()
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            Response.Cookies.Append("username", client.DownloadString("https://localhost:44363/api/auth/token"));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
