using MagicTheVotingAPI;
using System.IO;

namespace MagicTheVotingAPITests
{
    class MockFileReturningEmptyJsonArray : IFile
    {
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
