using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MagicTheQuotesAPI
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
            return GetMagicQuote(new File()).Result;
        }

        public async Task<ActionResult<string>> GetMagicQuote(IFile file)
        {
            MagicQuotes magicQuotes = GetMagicQuotesFromJsonFile(file);
            if (magicQuotes.Quotes.Length == 0)
                return NoContent();

            Random random = new Random();
            string randomMagicQuote = magicQuotes.Quotes[random.Next(magicQuotes.Quotes.Length)];
            if (string.IsNullOrEmpty(randomMagicQuote))
                return NotFound();
            return Ok(randomMagicQuote);
        }

        private MagicQuotes GetMagicQuotesFromJsonFile(IFile file)
        {
            string json = file.ReadAllText(magicQuotesFilePath);
            MagicQuotes magicQuotes = new MagicQuotes();
            JsonConvert.PopulateObject(json, magicQuotes);
            return magicQuotes;
        }
    }
}
