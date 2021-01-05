using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicTheVotingAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagicCardsController : ControllerBase
    {
        private readonly MagicTheVotingAPIContext _context;

        public MagicCardsController(MagicTheVotingAPIContext context)
        {
            _context = context;
        }

        // GET: api/MagicCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagicCard>>> GetMagicCard()
        {
            return await _context.MagicCard.ToListAsync();
        }

        // GET: api/MagicCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MagicCard>> GetMagicCard(int id)
        {
            var magicCard = await _context.MagicCard.FindAsync(id);

            if (magicCard == null)
            {
                return NotFound();
            }

            return magicCard;
        }

        // PUT: api/MagicCards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagicCard(int id, MagicCard magicCard)
        {
            if (id != magicCard.MultiverseId)
            {
                return BadRequest();
            }

            _context.Entry(magicCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagicCardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MagicCards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MagicCard>> PostMagicCard(MagicCard magicCard)
        {
            _context.MagicCard.Add(magicCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagicCard", new { id = magicCard.MultiverseId }, magicCard);
        }

        // DELETE: api/MagicCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MagicCard>> DeleteMagicCard(int id)
        {
            var magicCard = await _context.MagicCard.FindAsync(id);
            if (magicCard == null)
            {
                return NotFound();
            }

            _context.MagicCard.Remove(magicCard);
            await _context.SaveChangesAsync();

            return magicCard;
        }

        private bool MagicCardExists(int id)
        {
            return _context.MagicCard.Any(e => e.MultiverseId == id);
        }
    }
}
