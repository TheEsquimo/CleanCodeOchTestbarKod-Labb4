using System;

namespace MagicTheVotingAPI
{
    public class MagicVotePair
    {
        public Guid Id { get; set; }
        public MagicCard CardA { get; set; }
        public MagicCard CardB { get; set; }
        public int CardAVotes { get; set; }
        public int CardBVotes { get; set; }
    }
}
