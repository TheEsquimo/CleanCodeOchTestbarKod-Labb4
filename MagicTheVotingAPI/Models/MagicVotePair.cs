﻿using System;

namespace MagicTheVotingAPI
{
    public class MagicVotePair
    {
        public int Id { get; set; }
        public string CardA { get; set; }
        public string CardB { get; set; }
        public int CardAVotes { get; set; }
        public int CardBVotes { get; set; }
    }
}
