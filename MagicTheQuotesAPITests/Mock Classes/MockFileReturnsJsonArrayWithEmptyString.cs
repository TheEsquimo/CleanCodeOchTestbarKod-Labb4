using MagicTheQuotesAPI;

namespace MagicTheQuotesAPITests
{
    class MockFileReturnsJsonArrayWithEmptyString : IFile
    {
        public string ReadAllText(string path)
        {
            return @"{
              ""magicQuotes"": [
                """",
                """"
              ]
            }";
        }
    }
}
