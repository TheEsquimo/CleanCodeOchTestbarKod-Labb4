using MagicTheQuotesAPI;
using System;

namespace MagicTheQuotesAPITests
{
    class MockFileReturnsJsonArrayWithQuote : IFile
    {
        public string ReadAllText(string path)
        {
            return @"{
              ""magicQuotes"": [
                ""Test quote, very quote!""
              ]
            }";
        }
    }
}
