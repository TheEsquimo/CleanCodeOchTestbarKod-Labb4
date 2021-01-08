using RestClient.Net;
using System;
using System.Threading.Tasks;

namespace CleanCodeOchTestbarKod_Labb4
{
    public static class GameController
    {
        public static async Task<PercentagePair> GetPercentagesOfValuesTotal(double valueA, double valueB)
        {
            var client = new Client(new Uri($"http://calculatorapi/calculator?a={valueA}&b={valueB}"));
            double[] percentages = await client.GetAsync<double[]>();
            PercentagePair percentagePair = new PercentagePair(percentages[0], percentages[1]);
            return percentagePair;
        }

        public static async Task<MagicVotePair> GetRandomMagicVotePair()
        {
            var client = new Client(new Uri($"http://magicthevotingapi/magiccards/"));
            MagicVotePair randomMagicVotePair = await client.GetAsync<MagicVotePair>();
            return randomMagicVotePair;
        }

        public static async Task<string> GetRandomMagicQuote()
        {
            var client = new Client(new Uri($"http://magicthequotesapi/magicquotes/"));
            string randomMagicQuote = await client.GetAsync<string>();
            return randomMagicQuote;
        }
    }
}
