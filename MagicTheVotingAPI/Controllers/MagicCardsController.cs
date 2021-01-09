﻿using System;
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
        private IFile file;

        public MagicCardsController(IFile? file, string? path)
        {
            if (file != null)
                this.file = file;
            else
                this.file = new File();

            if (path != null)
                magicCardsFilePath = path;
            else
                magicCardsFilePath = Path.Combine(Environment.CurrentDirectory, @"Data/magic-cards.json");
        }

        [HttpGet]
        public async Task<ActionResult<MagicVotePair>> GetMagicVotePair()
        {
            MagicVotePairs magicVotePairs = GetMagicVotePairsFromJsonFile();
            if (magicVotePairs.MagicVotePairList.Length == 0)
                return NoContent();

            Random random = new Random();
            MagicVotePair randomMagicVotePair = magicVotePairs.MagicVotePairList[random.Next(magicVotePairs.MagicVotePairList.Length)];
            return Ok(randomMagicVotePair);
        }

        [HttpPut]
        public async Task<IActionResult> PutMagicVotePair(int id, string cardToGetVote)
        {
            cardToGetVote = cardToGetVote.ToUpper();
            MagicVotePairs magicVotePairs = GetMagicVotePairsFromJsonFile();

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

            using (StreamWriter streamWriterFile = file.CreateText(magicCardsFilePath))
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

        private MagicVotePairs GetMagicVotePairsFromJsonFile()
        {
            string json = file.ReadAllText(magicCardsFilePath);
            MagicVotePairs magicVotePairs = new MagicVotePairs();
            JsonConvert.PopulateObject(json, magicVotePairs);
            return magicVotePairs;
        }
    }
}
