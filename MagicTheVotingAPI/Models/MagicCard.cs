using System.ComponentModel.DataAnnotations;

namespace MagicTheVotingAPI
{
    public class MagicCard
    {
        [Key]
        public int MultiverseId { get; set; }
    }
}
