using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthorizationsController : ControllerBase
    {
        private readonly KontiKholodowContext _context;

        public UserAuthorizationsController(KontiKholodowContext context)
        {
            _context = context;
        }

        // GET: api/UserAuthorizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAuthorization>>> GetUserAuthorizations()
        {
          if (_context.UserAuthorizations == null)
          {
              return NotFound();
          }
            return await _context.UserAuthorizations.ToListAsync();
        }

        // GET: api/UserAuthorizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAuthorization>> GetUserAuthorization(int id)
        {
          if (_context.UserAuthorizations == null)
          {
              return NotFound();
          }
            var userAuthorization = await _context.UserAuthorizations.FindAsync(id);

            if (userAuthorization == null)
            {
                return NotFound();
            }

            return userAuthorization;
        }

        // PUT: api/UserAuthorizations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAuthorization(int id, UserAuthorization userAuthorization)
        {
            if (id != userAuthorization.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(userAuthorization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAuthorizationExists(id))
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

        // POST: api/UserAuthorizations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserAuthorization>> PostUserAuthorization(UserAuthorization userAuthorization)
        {
          if (_context.UserAuthorizations == null)
          {
              return Problem("Entity set 'KontiKholodowContext.UserAuthorizations'  is null.");
          }
            _context.UserAuthorizations.Add(userAuthorization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserAuthorization", new { id = userAuthorization.IdUser }, userAuthorization);
        }

        // DELETE: api/UserAuthorizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAuthorization(int id)
        {
            if (_context.UserAuthorizations == null)
            {
                return NotFound();
            }
            var userAuthorization = await _context.UserAuthorizations.FindAsync(id);
            if (userAuthorization == null)
            {
                return NotFound();
            }

            _context.UserAuthorizations.Remove(userAuthorization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAuthorizationExists(int id)
        {
            return (_context.UserAuthorizations?.Any(e => e.IdUser == id)).GetValueOrDefault();
        }
    }
}
