using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioAPI.Models;

namespace SistemaInventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly DbSIAPIContext _context;

        public ProveedoresController(DbSIAPIContext context)
        {
            _context = context;
        }

        // GET: api/Proveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> obtenerListaProveedores()
        {
          if (_context.Proveedores == null)
          {
              return NotFound();
          }
            return await _context.Proveedores.ToListAsync();
        }

        // GET: api/Proveedores/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Proveedor>> obtenerProveedor(int id)
        {
          if (_context.Proveedores == null)
          {
              return NotFound();
          }
            var proveedor = await _context.Proveedores.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return proveedor;
        }

        [HttpGet]
        [Route("{name:alpha}")]
        public Task<ActionResult<Proveedor>> obtenerProveedor(string name)
        {
            if (_context.Proveedores == null)
            {
                return Task.FromResult<ActionResult<Proveedor>>(NotFound());
            }

            var proveedor = _context.Proveedores.FirstOrDefault(pro => pro.Nombre.ToLower() == name.ToLower());

            if (proveedor == null)
            {
                return Task.FromResult<ActionResult<Proveedor>>(NotFound());
            }

            return Task.FromResult<ActionResult<Proveedor>>(proveedor);
        }

        // PUT: api/Proveedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id, Proveedor proveedor)
        {
            if (id != proveedor.Idproveedor)
            {
                return BadRequest();
            }

            _context.Entry(proveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
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

        // POST: api/Proveedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor(Proveedor proveedor)
        {
          if (_context.Proveedores == null)
          {
              return Problem("Entity set 'DbSIAPIContext.Proveedors'  is null.");
          }
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProveedor", new { id = proveedor.Idproveedor }, proveedor);
        }

        // DELETE: api/Proveedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            if (_context.Proveedores == null)
            {
                return NotFound();
            }
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProveedorExists(int id)
        {
            return (_context.Proveedores?.Any(e => e.Idproveedor == id)).GetValueOrDefault();
        }
    }
}
