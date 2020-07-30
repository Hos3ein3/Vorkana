using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interface;
using Web.Models;
using System.IO;
using Common.GenericController;

namespace Web.Controllers
{
    public class HomeController : GenericController
    {
        private readonly IStateService stateService;
        private readonly ICityService cityService;
        private readonly ICountryService countryService;
        public HomeController(ICountryService _countryService, IStateService _stateService, ICityService _cityService)
        {
            cityService = _cityService;
            stateService = _stateService;
            countryService = _countryService;
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
