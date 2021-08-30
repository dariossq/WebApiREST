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
    public class NoticiasController : ControllerBase
    {
        private readonly SStoreDBContext _context;

        public NoticiasController(SStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Noticias
        [HttpGet]
        public IEnumerable<Noticia> GetNoticia()
        {
            return _context.Noticia;
        }

        // GET: api/Ciudades/Nombre
        [HttpGet("{Nombre}")]
        public Noticia get(String Nombre)
        {
            var ciudad = _context.Ciudad.FirstOrDefault(p => p.CiudadNombre == Nombre);
            var clima = _context.Clima.FirstOrDefault(p => p.CiudadId == ciudad.CiudadId);
            var count = _context.Clima.Count();          
            

            var noticia = _context.Noticia.FirstOrDefault(p => p.ClimaId == clima.ClimaId);

            return noticia;
            //noticia = _context.Noticia.FirstOrDefault(p =>
            //                                          p.NoticiaAutor == Nombre);

        }


        //// GET: api/Ciudades/Nombre
        //[HttpGet("{Nombre}")]
        //public Noticia Obtener(string Nombre, int hola)
        //{
        //    var noticia = new Noticia();
        //    try
        //    {

        //        noticia = _context.Noticia.FirstOrDefault(p =>
        //                                                  p.NoticiaAutor == Nombre
        //                                                  .Where(p.ClimaId = hola);



        //        //noticia = _context.Noticia
        //        //                    .Include("Noticia")
        //        //                    .Where(x => x.NoticiaAutor == Nombre)
        //        //                    .Single();

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }

        //    return noticia;
        //}


        // GET: api/Noticias/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetNoticia([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var noticia = await _context.Noticia.FindAsync(id);

        //    if (noticia == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(noticia);
        //}

        // PUT: api/Noticias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoticia([FromRoute] int id, [FromBody] Noticia noticia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != noticia.NoticiaId)
            {
                return BadRequest();
            }

            _context.Entry(noticia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiaExists(id))
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

        // POST: api/Noticias
        [HttpPost]
        public async Task<IActionResult> PostNoticia([FromBody] Noticia noticia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Noticia.Add(noticia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNoticia", new { id = noticia.NoticiaId }, noticia);
        }

        // DELETE: api/Noticias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoticia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var noticia = await _context.Noticia.FindAsync(id);
            if (noticia == null)
            {
                return NotFound();
            }

            _context.Noticia.Remove(noticia);
            await _context.SaveChangesAsync();

            return Ok(noticia);
        }

        private bool NoticiaExists(int id)
        {
            return _context.Noticia.Any(e => e.NoticiaId == id);
        }
    }
}