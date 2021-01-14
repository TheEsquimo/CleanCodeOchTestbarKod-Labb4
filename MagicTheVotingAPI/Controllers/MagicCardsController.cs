using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicTheVotingAPI
{
    [ApiController]
    [Route("[controller]")]
    public class MagicCardsController : ControllerBase
    {
        private readonly string magicCardsFilePath;
        private static MagicVotePair lastFetchedMagicPair;
        private static bool canUndo = false;

        public MagicCardsController()
        {
            magicCardsFilePath = Path.Combine(Environment.CurrentDirectory, @"Data/magic-cards.json");
        }

        [HttpGet]
        public async Task<ActionResult<MagicVotePair>> GetMagicVotePair()
        {
            return GetMagicVotePair(new File()).Result;
        }
        public async Task<ActionResult<MagicVotePair>> GetMagicVotePair(IFile file)
        {
            MagicVotePairs magicVotePairs = GetMagicVotePairsFromJsonFile(file);
            if (magicVotePairs.MagicVotePairList.Length == 0)
                return NoContent();

            Random random = new Random();
            MagicVotePair randomMagicVotePair = magicVotePairs.MagicVotePairList[random.Next(magicVotePairs.MagicVotePairList.Length)];
            lastFetchedMagicPair = randomMagicVotePair;
            return Ok(randomMagicVotePair);
        }

        [HttpPut]
        public async Task<IActionResult> PutMagicVotePair(int id, string cardToGetVote)
        {
            return PutMagicVotePair(id, cardToGetVote, new File(), magicCardsFilePath).Result;
        }

        public async Task<IActionResult> PutMagicVotePair(int id, string cardToGetVote, IFile file, string filePath)
        {
            if (string.IsNullOrEmpty(cardToGetVote))
                return BadRequest("Invalid input");
            cardToGetVote = cardToGetVote.ToUpper();

            MagicVotePairs magicVotePairs = GetMagicVotePairsFromJsonFile(file);

            if (magicVotePairs.MagicVotePairList.Length == 0)
                return NoContent();

            MagicVotePair pairToModify = magicVotePairs.MagicVotePairList.Where(votePair => votePair.Id == id).FirstOrDefault();
            if (pairToModify == null)
                return NotFound();

            if (cardToGetVote != "A" && cardToGetVote != "B")
                return BadRequest("Invalid input of card to vote on. Must be either A or B.");

            if (cardToGetVote == "A")
                pairToModify.CardAVotes++;
            else
                pairToModify.CardBVotes++;

            using (StreamWriter streamWriterFile = file.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                try
                {
                    serializer.Serialize(streamWriterFile, magicVotePairs);
                    lastFetchedMagicPair = pairToModify;
                    canUndo = true;
                    return Ok(pairToModify);
                }
                catch
                {
                    return StatusCode(500);
                }
            }
        }

        [Route("last-fetched-pair")]
        [HttpGet]
        public async Task<ActionResult<MagicVotePair>> GetLastFetchedMagicVotePair()
        {
            if (lastFetchedMagicPair == null)
                return NoContent();
            return Ok(lastFetchedMagicPair);
        }

        [Route("undo-last-vote")]
        [HttpPut]
        public async Task<ActionResult<MagicVotePair>> UndoLastMagicPairVote(string cardThatWasVotedOn)
        {
            if (!canUndo)
                return NotFound("There's nothing to undo");

            if (string.IsNullOrEmpty(cardThatWasVotedOn))
                return BadRequest("Invalid input");
            cardThatWasVotedOn = cardThatWasVotedOn.ToUpper();

            if (cardThatWasVotedOn != "A" && cardThatWasVotedOn != "B")
                return BadRequest("Invalid input of card to undo vote on. Must be either A or B.");

            MagicVotePairs magicVotePairs = GetMagicVotePairsFromJsonFile(new File());
            if (lastFetchedMagicPair == null || magicVotePairs.MagicVotePairList.Length == 0)
                return NoContent();

            MagicVotePair pairToModify = magicVotePairs.MagicVotePairList.Where(votePair => votePair.Id == lastFetchedMagicPair.Id).FirstOrDefault();
            if (pairToModify == null)
                return NotFound();

            if (cardThatWasVotedOn == "A")
                pairToModify.CardAVotes--;
            else
                pairToModify.CardBVotes--;


            using (StreamWriter streamWriterFile = new File().CreateText(magicCardsFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                try
                {
                    serializer.Serialize(streamWriterFile, magicVotePairs);
                    canUndo = false;
                    lastFetchedMagicPair = pairToModify;
                    return Ok(pairToModify);
                }
                catch
                {
                    return StatusCode(500);
                }
            }
        }

        private MagicVotePairs GetMagicVotePairsFromJsonFile(IFile file)
        {
            string json = file.ReadAllText(magicCardsFilePath);
            MagicVotePairs magicVotePairs = new MagicVotePairs();
            JsonConvert.PopulateObject(json, magicVotePairs);
            return magicVotePairs;
        }
    }
}
