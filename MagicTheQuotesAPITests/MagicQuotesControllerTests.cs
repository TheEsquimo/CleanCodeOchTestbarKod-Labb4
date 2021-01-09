using MagicTheQuotesAPI;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace MagicTheQuotesAPITests
{
    public class MagicQuotesControllerTests
    {
        MagicQuotesController magicQuotesController;

        [SetUp]
        public void Setup()
        {
            magicQuotesController = new MagicQuotesController();
        }

        [Test]
        public void GivenAJsonFileWithEmptyArray_ReturnsNoContentHTTPCode()
        {
            var mockFile = new MockFileReturnsEmptyJsonArray();
            var actual = magicQuotesController.GetMagicQuote(mockFile);
            Assert.AreEqual(typeof(NoContentResult), actual.Result.Result.GetType());
        }

        [Test]
        public void GivenAJsonFileWithArrayOfEmptyStrings_ReturnsNotFoundHTTPCode()
        {
            var mockFile = new MockFileReturnsJsonArrayWithEmptyString();
            var actual = magicQuotesController.GetMagicQuote(mockFile);
            Assert.AreEqual(typeof(NotFoundResult), actual.Result.Result.GetType());
        }

        [Test]
        public void GivenAJsonFileWithCorrectFormat_ReturnsOkHTTPCode()
        {
            var mockFile = new MockFileReturnsJsonArrayWithQuote();
            var actual = magicQuotesController.GetMagicQuote(mockFile);
            Assert.AreEqual(typeof(OkObjectResult), actual.Result.Result.GetType());
        }
    }
}