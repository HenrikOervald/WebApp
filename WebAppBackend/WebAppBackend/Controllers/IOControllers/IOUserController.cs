using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBackend.Models;
using WebAppBackend.Models.DBmodels;
using WebAppBackend.Models.IOmodels;

namespace WebAppBackend.Controllers.IOControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IOUserController : Controller
    {
        private readonly IODBContext _context;
        public IOUserController(IODBContext context)
        {
            _context = context;
        }

        // GET: IOUserController/Details/username
        [HttpGet("{username}")]
        public async Task<ActionResult<IEnumerable<IOUser>>> GetUserWithUserFlowers(string username)
        {
            if(username == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(username);

            if(user == null)
            {
                return NotFound();
            }

            var userFlower = _context.User_Flowers.Where(uf => uf.Username.Contains(username)).ToList<User_Flower>();

            return Ok(new IOUser(
                user.Username,
                user.First_name,
                user.Last_name,
                user.Password,
                userFlower
                ));

        }
    }
}
