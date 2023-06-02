using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioAPI.Models;

namespace SistemaInventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacorasController : ControllerBase
    {
        private readonly DbSIAPIContext _context;

        public BitacorasController(DbSIAPIContext context)
        {
            _context = context;
        }

        // GET: api/Bitacoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bitacora>>> obtenerBitacora()
        {
          if (_context.Bitacora == null)
          {
              return NotFound();
          }
            return await _context.Bitacora.ToListAsync();
        }

        //// GET: api/Bitacoras/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Bitacora>> GetBitacora(int id)
        //{
        //  if (_context.Bitacora == null)
        //  {
        //      return NotFound();
        //  }
        //    var bitacora = await _context.Bitacora.FindAsync(id);

        //    if (bitacora == null)
        //    {
        //        return NotFound();
        //    }

        //    return bitacora;
        //}

        // PUT: api/Bitacoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBitacora(int id, Bitacora bitacora)
        //{
        //    if (id != bitacora.Idbitacora)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(bitacora).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BitacoraExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Bitacoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bitacora>> agregarBitacora(Bitacora bitacora)
        {
          if (_context.Bitacora == null)
          {
              return Problem("Entity set 'DbSIAPIContext.Bitacora'  is null.");
          }
            _context.Bitacora.Add(bitacora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBitacora", new { id = bitacora.Idbitacora }, bitacora);
        }

        //// DELETE: api/Bitacoras/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBitacora(int id)
        //{
        //    if (_context.Bitacora == null)
        //    {
        //        return NotFound();
        //    }
        //    var bitacora = await _context.Bitacora.FindAsync(id);
        //    if (bitacora == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Bitacora.Remove(bitacora);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool BitacoraExists(int id)
        //{
        //    return (_context.Bitacora?.Any(e => e.Idbitacora == id)).GetValueOrDefault();
        //}
    }
}
