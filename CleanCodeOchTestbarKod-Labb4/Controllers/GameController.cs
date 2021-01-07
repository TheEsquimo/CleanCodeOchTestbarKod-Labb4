using System;
using System.Collections.Generic;
using System.Linq;
using RestClient.Net;
using System.Threading.Tasks;

namespace CleanCodeOchTestbarKod_Labb4
{
    public static class GameController
    {
        public static async Task<PercentagePair> GetPercentagesOfValuesTotal(double valueA, double valueB)
        {
            var client = new Client(new Uri($"http://calculatorapi/calculator?a={valueA}&b={valueB}"));
            PercentagePair percentagePair = await client.GetAsync<PercentagePair>();
            return percentagePair;
        }
    }
}
