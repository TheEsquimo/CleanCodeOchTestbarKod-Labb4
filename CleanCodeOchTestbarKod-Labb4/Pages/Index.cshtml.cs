﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeOchTestbarKod_Labb4.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            ViewData["Message"] = "Hello from webfrontend";

            using (var client = new System.Net.Http.HttpClient())
            {
                var request = new System.Net.Http.HttpRequestMessage();
                request.RequestUri = new Uri("http://calculatorapi/calculator?a=5&b=10");
                var response = await client.SendAsync(request);
                PercentagePair percentagePair = await GameController.GetPercentagesOfValuesTotal(5, 10);
                ViewData["Message"] += " and " + percentagePair.PercentageAWithPercentageSymbol + " " + percentagePair.PercentageBWithPercentageSymbol;
            }
        }
    }
}
