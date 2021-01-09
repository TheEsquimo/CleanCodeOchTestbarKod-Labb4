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
            return Ok(randomMagicVotePair);
        }

        [HttpPut]
        public async Task<IActionResult> PutMagicVotePair(int id, string cardToGetVote)
        {
            return PutMagicVotePair(id, cardToGetVote, new File(), magicCardsFilePath).Result;
        }

        public async Task<IActionResult> PutMagicVotePair(int id, string cardToGetVote, IFile file, string filePath)
        {
            cardToGetVote = cardToGetVote.ToUpper();
            MagicVotePairs magicVotePairs = GetMagicVotePairsFromJsonFile(file);

            if (magicVotePairs.MagicVotePairList.Length == 0)
                return NoContent();

            MagicVotePair pairToModify = magicVotePairs.MagicVotePairList.Where(votePair => votePair.Id == id).FirstOrDefault();
            if (pairToModify == null)
                return NotFound();

            if (cardToGetVote != "A" && cardToGetVote != "B")
                return BadRequest("Invalid input of card to vote. Must be either A or B.");

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
