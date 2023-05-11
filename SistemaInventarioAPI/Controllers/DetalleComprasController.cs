using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioAPI.Models;

namespace SistemaInventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleComprasController : ControllerBase
    {
        private readonly DbSIAPIContext _context;

        public DetalleComprasController(DbSIAPIContext context)
        {
            _context = context;
        }

        // GET: api/DetalleCompras
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DetalleCompra>>> GetDetalleCompras()
        //{
        //  if (_context.DetalleCompras == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.DetalleCompras.ToListAsync();
        //}

        // GET: api/DetalleCompras/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<DetalleCompra>> GetDetalleCompra(int id)
        //{
        //  if (_context.DetalleCompras == null)
        //  {
        //      return NotFound();
        //  }
        //    var detalleCompra = await _context.DetalleCompras.FindAsync(id);

        //    if (detalleCompra == null)
        //    {
        //        return NotFound();
        //    }

        //    return detalleCompra;
        //}

        //GET
        [HttpGet]
        [Route("{compraID:int}")]
        public async Task<ActionResult<IEnumerable<DetalleCompra>>> obtenerDetalleCompra(int compraID)
        {
            if (_context.DetalleCompras == null)
            {
                return NotFound();
            }

            return await _context.DetalleCompras.Where(d => d.Idcompra == compraID).ToListAsync();
        }

        // PUT: api/DetalleCompras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleCompra(int id, DetalleCompra detalleCompra)
        {
            if (id != detalleCompra.IddetalleCompra)
            {
                return BadRequest();
            }

            _context.Entry(detalleCompra).State = EntityState.Modified;

            var producto = await _context.Productos.FindAsync(detalleCompra.Idproducto);
            if (!(producto == null))
            {
                var actual = await _context.DetalleCompras.FindAsync(id);
                if (!(actual == null))
                {
                    if (actual.Cantidad > detalleCompra.Cantidad)
                    {
                        producto.Cantidad += (actual.Cantidad - detalleCompra.Cantidad);
                        _context.Entry(producto).State = EntityState.Modified;
                    }
                    else if (actual.Cantidad < detalleCompra.Cantidad)
                    {
                        producto.Cantidad -= (detalleCompra.Cantidad - actual.Cantidad);
                        _context.Entry(producto).State = EntityState.Modified;
                    }
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleCompraExists(id))
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

        // POST: api/DetalleCompras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleCompra>> PostDetalleCompra(DetalleCompra detalleCompra)
        {
          if (_context.DetalleCompras == null)
          {
              return Problem("Entity set 'DbSIAPIContext.DetalleCompras'  is null.");
          }
            _context.DetalleCompras.Add(detalleCompra);

            var producto = await _context.Productos.FindAsync(detalleCompra.Idproducto);
            if (!(producto == null))
            {
                producto.Cantidad -= detalleCompra.Cantidad;
                _context.Entry(producto).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleCompra", new { id = detalleCompra.IddetalleCompra }, detalleCompra);
        }

        // DELETE: api/DetalleCompras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleCompra(int id)
        {
            if (_context.DetalleCompras == null)
            {
                return NotFound();
            }
            var detalleCompra = await _context.DetalleCompras.FindAsync(id);
            if (detalleCompra == null)
            {
                return NotFound();
            }

            _context.DetalleCompras.Remove(detalleCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleCompraExists(int id)
        {
            return (_context.DetalleCompras?.Any(e => e.IddetalleCompra == id)).GetValueOrDefault();
        }
    }
}
