using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EncoraCodingExercise.Web.Models;
using Microsoft.Extensions.Configuration;
using EncoraCodingExercise.Web.Services;

namespace EncoraCodingExercise.Web.Controllers
{
    public class HomeController : Controller
    {
        public IPropertyService _propertyService { get; set; }

        public HomeController(IPropertyService propertyService) => _propertyService = propertyService;

        public async  Task<IActionResult> Index()
        {
            var response = await _propertyService.GetCatalogItems();
            return View(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
