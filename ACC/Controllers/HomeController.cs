using ACC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reporting.Client.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    public class HomeController : Controller
    {
        private readonly IReportingClient _reportingClient;

        public HomeController(IReportingClient reportingClient)
        {
            _reportingClient = reportingClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Report(string firstCatalogMetadataJson, string secondCatalogMetadataJson)
        {
            var report = (await _reportingClient.GetGeneratedReport(firstCatalogMetadataJson, secondCatalogMetadataJson)).Content;

            return View(report);
        }
    }
}
