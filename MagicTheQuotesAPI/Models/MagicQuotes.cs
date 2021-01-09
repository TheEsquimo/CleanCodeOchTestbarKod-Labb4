using Newtonsoft.Json;

namespace MagicTheQuotesAPI
{
    public partial class MagicQuotes
    {
        [JsonProperty("magicQuotes")]
        public string[] Quotes { get; set; }
    }
}
