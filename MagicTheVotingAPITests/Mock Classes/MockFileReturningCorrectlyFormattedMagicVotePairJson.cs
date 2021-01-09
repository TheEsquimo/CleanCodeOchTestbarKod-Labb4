using MagicTheVotingAPI;
using System.IO;

namespace MagicTheVotingAPITests
{
    class MockFileReturningCorrectlyFormattedMagicVotePairJson : IFile
    {
        public StreamWriter CreateText(string path)
        {
            return new StreamWriter(path);
        }

        public string ReadAllText(string path)
        {
            return @"{
              ""magicVotePairs"": [
                {
                  ""id"": 1,
                  ""cardA"": 466756,
                  ""cardB"": 469852,
                  ""cardAVotes"": 0,
                  ""cardBVotes"": 0
                }
              ]
            }";
        }
    }
}
