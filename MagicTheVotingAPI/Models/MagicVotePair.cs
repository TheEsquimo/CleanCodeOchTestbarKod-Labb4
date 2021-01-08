using Newtonsoft.Json;
using System;

namespace MagicTheVotingAPI
{
    public partial class MagicVotePairs
    {
        [JsonProperty("magicVotePairs")]
        public MagicVotePair[] MagicVotePairList { get; set; }
    }

    public partial class MagicVotePair
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cardA")]
        public int CardA { get; set; }

        [JsonProperty("cardB")]
        public int CardB { get; set; }

        [JsonProperty("cardAVotes")]
        public int CardAVotes { get; set; }

        [JsonProperty("cardBVotes")]
        public int CardBVotes { get; set; }
    }
}
