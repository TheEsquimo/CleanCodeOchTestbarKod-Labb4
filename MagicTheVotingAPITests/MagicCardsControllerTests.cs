using NUnit.Framework;
using MagicTheVotingAPI;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MagicTheVotingAPITests
{
    public class MagicCardsControllerTests
    {
        string magicCardsFilePath = Path.Combine(Environment.CurrentDirectory, @"Data/magic-cards-mock.json");
        MagicCardsController magicCardsController;

        [SetUp]
        public void Setup()
        {
            magicCardsController = new MagicCardsController();
        }

        [Test]
        public void GivenAJsonFileOfCorrectFormat_ReturnsOkHTTPCode()
        {
            var mockFile = new MockFileReturningCorrectlyFormattedMagicVotePairJson();
            var actual = magicCardsController.GetMagicVotePair(mockFile);
            Assert.AreEqual(typeof(OkObjectResult), actual.Result.Result.GetType());
        }

        [Test]
        public void GivenAJsonFileOfEmptyArray_ReturnsNoContentHTTPCode()
        {
            var mockFile = new MockFileReturningEmptyJsonArray();
            mockFile.MagicVotePairId = 1;
            mockFile.CardToVoteOn = "a";
            var actualGet = magicCardsController.GetMagicVotePair(mockFile);
            var actualPut = magicCardsController.PutMagicVotePair(mockFile.MagicVotePairId, mockFile.CardToVoteOn, mockFile, null);
            Assert.AreEqual(typeof(NoContentResult), actualGet.Result.Result.GetType());
            Assert.AreEqual(typeof(NoContentResult), actualPut.Result.GetType());
        }

        [Test]
        public void GivenAnIdAndJsonFileNotContaintingThatId_ReturnsNotFoundHTTPCode()
        {
            var mockFile = new MockFileReturningCorrectlyFormattedMagicVotePairJson();
            var actual = magicCardsController.PutMagicVotePair(3, "A", mockFile, null);
            Assert.AreEqual(typeof(NotFoundResult), actual.Result.GetType());
        }

        [Test]
        public void NotGivenAorBAsCardToVoteOn_ReturnsBadRequestHTTPCode()
        {
            var mockFile = new MockFileReturningCorrectlyFormattedMagicVotePairJson();
            var actual = magicCardsController.PutMagicVotePair(1, "k", mockFile, null);
            Assert.AreEqual(typeof(BadRequestObjectResult), actual.Result.GetType());
        }
    }
}