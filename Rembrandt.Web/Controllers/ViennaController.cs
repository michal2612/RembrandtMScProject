using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Rembrandt.Contracts.Classes.Dataset.ViennaObservations;
using Rembrandt.Web.ViewModels;

namespace Rembrandt.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class viennaController : Controller
    {
        public IActionResult Data()
        {
            return View(new ViennaDatasetViewModel() {
                ViennaObservation = new ViennaObservationDto()
            });
        }
    }
}