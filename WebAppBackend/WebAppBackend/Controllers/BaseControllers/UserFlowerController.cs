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
    public class UserFlowerController : ControllerBase
    {
        private readonly IODBContext _context;

        public UserFlowerController(IODBContext context)
        {
            _context = context;
        }

        // GET: api/UserFlower
        [HttpGet]
        public async Task<ActionResult<List<User_Flower>>> GetUser_Flowers()
        {
            return await _context.User_Flowers.ToListAsync();
        }

        // GET: api/UserFlower/5
        [HttpGet("{username}")]
        public async Task<ActionResult<List<User_Flower>>> GetUser_Flower(string username)
        {
            var user_Flower = await _context.User_Flowers.Where(uf => uf.Username == username).ToListAsync<User_Flower>(); ;

            if (user_Flower == null)
            {
                return NotFound();
            }

            return user_Flower;
        }

        // PUT: api/UserFlower/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser_Flower(int id, User_Flower user_Flower)
        {
            if (id != user_Flower.Id)
            {
                return BadRequest();
            }

            _context.Entry(user_Flower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_FlowerExists(id))
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

        // POST: api/UserFlower
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User_Flower>> PostUser_Flower(User_Flower user_Flower)
        {
            _context.User_Flowers.Add(user_Flower);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser_Flower", new { username = user_Flower.Username }, user_Flower);
        }

        // DELETE: api/UserFlower/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User_Flower>> DeleteUser_Flower(int id)
        {
            var user_Flower = await _context.User_Flowers.FindAsync(id);
            if (user_Flower == null)
            {
                return NotFound();
            }

            _context.User_Flowers.Remove(user_Flower);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool User_FlowerExists(int id)
        {
            return _context.User_Flowers.Any(e => e.Id == id);
        }
    }
}
