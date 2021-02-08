﻿using System;
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

        public   IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetProperties(int? page, int? limit,string sortBy, string direction, string searchString = null)
        {
            var response = await _propertyService.GetAllItems();
            List<ResponseViewModel> records;
            var queryResult = response.Data.Select(p => new ResponseViewModel { 
                Id = p.Id,
                Address = p.Address,
                YearBuilt = p.YearBuilt,
                ListPrice = p.ListPrice,
                MontlyRent = p.MontlyRent,
                GrossYield = p.GrossYield
            });
            var total = 5;
            records = queryResult.ToList();
            return Json(new { records, total });
        }

        [HttpPost]
        public async Task<JsonResult> Save(UserPropertyViewModel property)
        {
            //await _propertyService.Save(property)
            return Json(true);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
