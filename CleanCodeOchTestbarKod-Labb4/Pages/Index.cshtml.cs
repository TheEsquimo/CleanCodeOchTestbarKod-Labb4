using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CleanCodeOchTestbarKod_Labb4.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        [ViewData]
        public bool HasVoted { get; set; }
        [ViewData]
        public string CardImageA { get; set; }
        [ViewData]
        public string CardImageB { get; set; }
        [ViewData]
        public PercentagePair CardVoteDistributionPercentages { get; set; }
        [ViewData]
        public string MagicQuote { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            UpdateCardImagesToCurrentCardPair();
        }

        public async Task OnPostUserVoted(string cardVotedOn)
        {
            MagicTheVotingController.OnUserVoted(cardVotedOn);
            CardVoteDistributionPercentages = MagicTheVotingController.GetPercentagesDistributonOfVotes().Result;
            UpdateCardImagesToCurrentCardPair();
            MagicQuote = MagicTheVotingController.CurrentMagicQuote;
            HasVoted = true;
        }

        public async Task OnPostRequestNewCardPair()
        {
            MagicTheVotingController.OnUserRequestNewCardPair();
            UpdateCardImagesToCurrentCardPair();
            HasVoted = false;
        }

        private void UpdateCardImagesToCurrentCardPair()
        {
            MagicMultiverseIdConverter multiverseConverter = new MagicMultiverseIdConverter();
            CardImageA = multiverseConverter.ConvertMultiverseIdToImageLink(MagicTheVotingController.CurrentMagicVotePair.CardA);
            CardImageB = multiverseConverter.ConvertMultiverseIdToImageLink(MagicTheVotingController.CurrentMagicVotePair.CardB);
        }
    }
}
