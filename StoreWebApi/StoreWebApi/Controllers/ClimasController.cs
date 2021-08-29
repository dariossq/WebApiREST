using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreWebApi.Models;

namespace StoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimasController : ControllerBase
    {
        private readonly SStoreDBContext _context;

        public ClimasController(SStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Climas
        [HttpGet]
        public IEnumerable<Clima> GetClima()
        {
            return _context.Clima;
        }

        // GET: api/Climas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClima([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clima = await _context.Clima.FindAsync(id);

            if (clima == null)
            {
                return NotFound();
            }

            return Ok(clima);
        }

        // PUT: api/Climas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClima([FromRoute] int id, [FromBody] Clima clima)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clima.ClimaId)
            {
                return BadRequest();
            }

            _context.Entry(clima).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClimaExists(id))
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

        // POST: api/Climas
        [HttpPost]
        public async Task<IActionResult> PostClima([FromBody] Clima clima)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Clima.Add(clima);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClimaExists(clima.ClimaId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClima", new { id = clima.ClimaId }, clima);
        }

        // DELETE: api/Climas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClima([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clima = await _context.Clima.FindAsync(id);
            if (clima == null)
            {
                return NotFound();
            }

            _context.Clima.Remove(clima);
            await _context.SaveChangesAsync();

            return Ok(clima);
        }

        private bool ClimaExists(int id)
        {
            return _context.Clima.Any(e => e.ClimaId == id);
        }
    }
}