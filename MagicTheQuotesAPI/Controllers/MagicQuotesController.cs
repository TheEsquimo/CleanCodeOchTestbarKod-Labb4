using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicTheQuotesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MagicQuotesController : ControllerBase
    {
        private readonly string magicQuotesFilePath;
        public MagicQuotesController()
        {
            magicQuotesFilePath = Path.Combine(Environment.CurrentDirectory, @"Data/magic-quotes.json");
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetMagicQuote()
        {
            MagicQuotes magicQuotes = GetMagicQuotesFromJsonFile();
            if (magicQuotes.Quotes.Length == 0)
                return NoContent();

            Random random = new Random();
            string randomMagicQuote = magicQuotes.Quotes[random.Next(magicQuotes.Quotes.Length)];
            if (string.IsNullOrEmpty(randomMagicQuote))
                return NotFound();
            return Ok(randomMagicQuote);
        }

        private MagicQuotes GetMagicQuotesFromJsonFile()
        {
            string json = System.IO.File.ReadAllText(magicQuotesFilePath);
            MagicQuotes magicQuotes = new MagicQuotes();
            JsonConvert.PopulateObject(json, magicQuotes);
            return magicQuotes;
        }
    }
}
