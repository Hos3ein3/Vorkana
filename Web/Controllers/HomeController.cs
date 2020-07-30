﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
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
            return View();
        }

        [HttpGet]
        public IActionResult GetCitiesByStateId(int? stateId)
        {
            return null;
        }

        [HttpGet]
        public IActionResult GetStatesByCountryId(int? countryId)
        {
            return null;
        }

        [HttpGet]
        public IActionResult GetCountriesByRegion()
        {
            return null;
        }

        [HttpGet]
        public IActionResult CheckFileExist(string path)
        {
            return null;
        }

    }
}
