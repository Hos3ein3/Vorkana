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
using Common.Alerts;

namespace Web.Controllers
{
    public class HomeController : GenericController
    {
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        public HomeController(ICountryService countryService, IStateService stateService, ICityService cityService)
        {
            _cityService = cityService;
            _stateService = stateService;
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            //string test = Alerts.Success["LoginSuccess"];
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
