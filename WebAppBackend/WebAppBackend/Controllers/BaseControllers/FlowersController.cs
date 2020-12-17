using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppBackend.Models;
using WebAppBackend.Models.DBmodels;

namespace WebAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private readonly IODBContext _context;

        public FlowersController(IODBContext context)
        {
            _context = context;
        }

        // GET: api/Flowers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flower>>> GetDBFlowers()
        {
            return await _context.Flowers.ToListAsync();
        }

        // GET: api/Flowers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flower>> GetDBFlower(int id)
        {
            var dBFlower = await _context.Flowers.FindAsync(id);

            if (dBFlower == null)
            {
                return NotFound();
            }

            return dBFlower;
        }

        // PUT: api/Flowers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDBFlower(int id, Flower dBFlower)
        {
            if (id != dBFlower.Id)
            {
                return BadRequest();
            }

            _context.Entry(dBFlower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DBFlowerExists(id))
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

        // POST: api/Flowers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Flower>> PostDBFlower(Flower dBFlower)
        {
            _context.Flowers.Add(dBFlower);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDBFlower", new { id = dBFlower.Id }, dBFlower);
        }

        // DELETE: api/Flowers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flower>> DeleteDBFlower(int id)
        {
            var dBFlower = await _context.Flowers.FindAsync(id);
            if (dBFlower == null)
            {
                return NotFound();
            }

            _context.Flowers.Remove(dBFlower);
            await _context.SaveChangesAsync();

            return dBFlower;
        }

        private bool DBFlowerExists(int id)
        {
            return _context.Flowers.Any(e => e.Id == id);
        }
    }
}
