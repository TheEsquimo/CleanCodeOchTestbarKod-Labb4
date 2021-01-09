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
            var actual = magicCardsController.GetMagicVotePair(mockFile);
            Assert.AreEqual(typeof(NoContentResult), actual.Result.Result.GetType());
        }

        //private MagicVotePairs GetMagicVotePairsFromJsonFile()
        //{
        //    //string json = File.ReadAllText(magicCardsFilePath);
        //    //MagicVotePairs magicVotePairs = new MagicVotePairs();
        //    //JsonConvert.PopulateObject(json, magicVotePairs);
        //    //return magicVotePairs;
        //}
    }
}