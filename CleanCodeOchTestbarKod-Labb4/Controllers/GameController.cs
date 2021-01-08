using RestClient.Net;
using System;
using System.Threading.Tasks;

namespace CleanCodeOchTestbarKod_Labb4
{
    public static class GameController
    {
        public static MagicVotePair CurrentMagicVotePair { get { return currentMagicVotePair; } }
        public static string CurrentMagicQuote { get { return CurrentMagicQuote; } }

        private static MagicVotePair currentMagicVotePair = GetRandomMagicVotePair().Result;
        private static string currentMagicQuote;

        public static void OnUserVoted(string cardVotedOn)
        {
            RegisterVoteOnCurrentVotePair(cardVotedOn);
            currentMagicQuote = GetRandomMagicQuote().Result;
        }

        public static void OnUserRequestNewCardPair()
        {
            currentMagicVotePair = GetRandomMagicVotePair().Result;
        }
        
        private static async void RegisterVoteOnCurrentVotePair(string cardVotedOn)
        {
            var client = new Client(new Uri($"http://magicthevotingapi/magiccards?id={CurrentMagicVotePair.Id}&cardToGetVote={cardVotedOn}"));
            currentMagicVotePair = await client.PutAsync<MagicVotePair, MagicVotePair>();
        }

        public static async Task<PercentagePair> GetPercentagesDistributonOfVotes()
        {
            var client = new Client(new Uri($"http://calculatorapi/calculator?a={currentMagicVotePair.CardAVotes}&b={currentMagicVotePair.CardBVotes}"));
            double[] percentages = await client.GetAsync<double[]>();
            PercentagePair percentagePair = new PercentagePair(percentages[0], percentages[1]);
            return percentagePair;
        }


        private static async Task<MagicVotePair> GetRandomMagicVotePair()
        {
            var client = new Client(new Uri($"http://magicthevotingapi/magiccards/"));
            MagicVotePair randomMagicVotePair = await client.GetAsync<MagicVotePair>();
            return randomMagicVotePair;
        }

        private static async Task<string> GetRandomMagicQuote()
        {
            var client = new Client(new Uri($"http://magicthequotesapi/magicquotes/"));
            string randomMagicQuote = await client.GetAsync<string>();
            return randomMagicQuote;
        }
    }
}
