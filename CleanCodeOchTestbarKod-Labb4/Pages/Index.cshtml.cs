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
            GameController.OnUserVoted(cardVotedOn);
            CardVoteDistributionPercentages = GameController.GetPercentagesDistributonOfVotes().Result;
            UpdateCardImagesToCurrentCardPair();
            HasVoted = true;
        }

        public async Task OnPostRequestNewCardPair()
        {
            GameController.OnUserRequestNewCardPair();
            UpdateCardImagesToCurrentCardPair();
            HasVoted = false;
        }

        private void UpdateCardImagesToCurrentCardPair()
        {
            MagicMultiverseIdConverter multiverseConverter = new MagicMultiverseIdConverter();
            CardImageA = multiverseConverter.ConvertMultiverseIdToImageLink(GameController.CurrentMagicVotePair.CardA);
            CardImageB = multiverseConverter.ConvertMultiverseIdToImageLink(GameController.CurrentMagicVotePair.CardB);
        }
    }
}
