
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Linq;



namespace Common.GenericController
{
    class GenericController:Controller
    {
        public ControllerInfo fillControllerInfo()
        {
            return new ControllerInfo() { ModelState = ModelState, httpContext = HttpContext };
        }
    }
}
