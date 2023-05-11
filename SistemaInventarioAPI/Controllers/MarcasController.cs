using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioAPI.Models;

namespace SistemaInventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly DbSIAPIContext _context;

        public MarcasController(DbSIAPIContext context)
        {
            _context = context;
        }

        // GET: api/Marcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> obtenerListaMarcas()
        {
          if (_context.Marcas == null)
          {
              return NotFound();
          }
            return await _context.Marcas.ToListAsync();
        }

        // GET: api/Marcas/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Marca>> obtenerMarca(int id)
        {
          if (_context.Marcas == null)
          {
              return NotFound();
          }
            var marca = await _context.Marcas.FindAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            return marca;
        }

        [HttpGet]
        [Route("{name:alpha}")]
        public Task<ActionResult<Marca>> obtenerMarca(string name)
        {
            if (_context.Marcas == null)
            {
                return Task.FromResult<ActionResult<Marca>>(NotFound());
            }

            var marca = _context.Marcas.FirstOrDefault(mar => mar.Nombre.ToLower() == name.ToLower());

            if (marca == null)
            {
                return Task.FromResult<ActionResult<Marca>>(NotFound());
            }

            return Task.FromResult<ActionResult<Marca>>(marca);
        }

        // PUT: api/Marcas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> editarMarca(int id, Marca marca)
        {
            if (id != marca.Idmarca)
            {
                return BadRequest();
            }

            _context.Entry(marca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
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

        // POST: api/Marcas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Marca>> agregarMarca(Marca marca)
        {
          if (_context.Marcas == null)
          {
              return Problem("Entity set 'DbSIAPIContext.Marcas'  is null.");
          }
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarca", new { id = marca.Idmarca }, marca);
        }

        // DELETE: api/Marcas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarMarca(int id)
        {
            if (_context.Marcas == null)
            {
                return NotFound();
            }
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarcaExists(int id)
        {
            return (_context.Marcas?.Any(e => e.Idmarca == id)).GetValueOrDefault();
        }
    }
}
