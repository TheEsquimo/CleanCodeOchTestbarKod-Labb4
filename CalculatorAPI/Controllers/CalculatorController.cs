using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPercentagesOfTotal(int a, int b)
        {
            try
            {
                double[] percentages = Calculator.GetPercentagesOfTotal(a, b);
                return Ok(percentages);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}