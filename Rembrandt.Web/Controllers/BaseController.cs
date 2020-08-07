using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace Rembrandt.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly HttpClient _httpClient;

        public BaseController()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://51.104.49.19:5000")
            };
        }
    }
}
