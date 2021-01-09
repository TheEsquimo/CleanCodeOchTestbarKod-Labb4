using NUnit.Framework;
using MagicTheVotingAPI;
using Newtonsoft.Json;
using System.IO;
using System;

namespace MagicTheVotingAPITests
{
    public class MagicCardsControllerTests
    {
        string magicCardsFilePath = Path.Combine(Environment.CurrentDirectory, @"Data/magic-cards-mock.json");
        MagicCardsController magicCardsController;

        [SetUp]
        public void Setup()
        {
            //magicCardsController = new MagicCardsController(magicCardsFilePath);
        }

        [Test]
        public void GivenAPathToAJsonFileOfCorrectFormat_ReturnsObjectFromIt()
        {
            //MagicVotePair result = magicCardsController.GetMagicVotePair().Result.Value;
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