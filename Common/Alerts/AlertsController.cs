using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Alerts
{
    public class AlertsController : Controller
    {
        public enum alerts
        { 
            Success,
            Warning,
            Error,
            Info
        }

        public void SendAlert(string key,alerts alerts)
        {
            switch (alerts)
            {
                case alerts.Success:
                    TempData["GlobalSuccess"] = Alerts.Success[key];
                    break;
                case alerts.Warning:
                    TempData["GlobalWarning"] = Alerts.Warning[key];
                    break;
                case alerts.Error:
                    TempData["GlobalError"] = Alerts.Error[key];
                    break;
                case alerts.Info:
                    TempData["GlobalInfo"] = Alerts.Info[key];
                    break;
                default:
                    break;
            }
        }
    }
}
