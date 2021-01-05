using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController
    {
        [HttpGet]
        public double[] GetPercentagesOfTotal(int a, int b)
        {
            return Calculator.GetPercentagesOfTotal(a, b);
        }
    }
}