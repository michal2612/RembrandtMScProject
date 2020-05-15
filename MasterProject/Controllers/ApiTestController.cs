using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTestController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public IActionResult VoidFunction()
        {
            return Content("GOwno");
        }
    }
}