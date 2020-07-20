using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rembrandt.Contracts.Classes.Dataset;
using Rembrandt.Contracts.Classes.User;
using Rembrandt.Web.ViewModels;

namespace Rembrandt.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://51.104.49.19:5000")
            };
        }

        public async Task<IActionResult> Login(Login login)
        {
            var loginData = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("/login-gateway", loginData);
            if(responseMessage.IsSuccessStatusCode)
            {
                Response.Cookies.Append("jwtToken", responseMessage.Content.ReadAsStringAsync().Result);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "LogIn");
        }

        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            var registerData = new StringContent(JsonConvert.SerializeObject(register.RegisterData), Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("/register-gateway", registerData);
            if(responseMessage.IsSuccessStatusCode)
            {
                Response.Cookies.Append("jwtToken", responseMessage.Content.ReadAsStringAsync().Result);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Register", "LogIn");
        }

        public IActionResult LogOut()
        {
            try
            {
                Response.Cookies.Delete("jwtToken");
            }
            catch
            {

            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Settings()
        {
            return View(new ContributorDto());
        }
    }
}