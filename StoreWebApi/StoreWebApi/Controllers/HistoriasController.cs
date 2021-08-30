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
    public class HistoriasController : ControllerBase
    {
        private readonly SStoreDBContext _context;

        public HistoriasController(SStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Historias
        [HttpGet]
        public IEnumerable<Historia> GetHistoria()
        {
            return _context.Historia;
        }

        // GET: api/Historias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historia = await _context.Historia.FindAsync(id);

            if (historia == null)
            {
                return NotFound();
            }

            return Ok(historia);
        }

        // PUT: api/Historias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoria([FromRoute] int id, [FromBody] Historia historia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historia.HistoriaId)
            {
                return BadRequest();
            }

            _context.Entry(historia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriaExists(id))
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

        // POST: api/Historias
        [HttpPost]
        public async Task<IActionResult> PostHistoria([FromBody] Historia historia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Historia.Add(historia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoria", new { id = historia.HistoriaId }, historia);
        }

        // DELETE: api/Historias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var historia = await _context.Historia.FindAsync(id);
            if (historia == null)
            {
                return NotFound();
            }

            _context.Historia.Remove(historia);
            await _context.SaveChangesAsync();

            return Ok(historia);
        }

        private bool HistoriaExists(int id)
        {
            return _context.Historia.Any(e => e.HistoriaId == id);
        }
    }
}