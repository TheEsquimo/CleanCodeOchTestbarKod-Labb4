using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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