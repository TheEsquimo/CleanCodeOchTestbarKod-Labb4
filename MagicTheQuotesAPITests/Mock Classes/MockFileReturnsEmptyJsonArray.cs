using MagicTheQuotesAPI;

namespace MagicTheQuotesAPITests
{
    class MockFileReturnsEmptyJsonArray : IFile
    {
        public string ReadAllText(string path)
        {
            return @"{
              ""magicQuotes"": [
              ]
            }";
        }
    }
}
