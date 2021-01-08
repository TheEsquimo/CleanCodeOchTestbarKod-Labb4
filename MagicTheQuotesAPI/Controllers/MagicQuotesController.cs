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
            string[] magicQuotes = GetMagicQuotesFromJsonFile();
            if (magicQuotes.Length == 0)
                return NoContent();

            Random random = new Random();
            string randomMagicQuote = magicQuotes[random.Next(magicQuotes.Length)];
            return randomMagicQuote;
        }
        private string[] GetMagicQuotesFromJsonFile()
        {
            string json = System.IO.File.ReadAllText(magicQuotesFilePath);
            string[] magicQuotes = JsonConvert.DeserializeObject<string[]>(json);
            return magicQuotes;
        }
    }
}
