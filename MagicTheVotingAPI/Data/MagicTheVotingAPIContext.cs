using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MagicTheVotingAPI;

namespace MagicTheVotingAPI
{
    public class MagicTheVotingAPIContext : DbContext
    {
        public MagicTheVotingAPIContext (DbContextOptions<MagicTheVotingAPIContext> options)
            : base(options)
        {
        }
        public DbSet<MagicVotePair> MagicVotePair { get; set; }
    }
}