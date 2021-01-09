using MagicTheVotingAPI;
using System.IO;

namespace MagicTheVotingAPITests
{
    class MockFileReturningEmptyJsonArray : IFile
    {
        public int MagicVotePairId { get; set; }
        public string CardToVoteOn { get; set; }
        public StreamWriter CreateText(string path)
        {
            throw new System.NotImplementedException();
        }

        public string ReadAllText(string path)
        {
            return @"{
              ""magicVotePairs"": [
              ]
            }";
        }
    }
}
