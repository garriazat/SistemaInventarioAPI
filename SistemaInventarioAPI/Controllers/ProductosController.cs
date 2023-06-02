using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioAPI.Models;

namespace SistemaInventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DbSIAPIContext _context;

        public ProductosController(DbSIAPIContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> obtenerListaProductos()
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> obtenerProducto(int id)
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> editarProducto(int id, Producto producto)
        {
            if (id != producto.Idproducto)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'DbSIAPIContext.Productos'  is null.");
            }
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            altaProductoBitacora(producto);

            return CreatedAtAction("GetProducto", new { id = producto.Idproducto }, producto);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            bajaProductoBitacora(producto);

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return (_context.Productos?.Any(e => e.Idproducto == id)).GetValueOrDefault();
        }

        private void altaProductoBitacora(Producto producto)
        {
            Bitacora bitacora = new Bitacora();

            bitacora.Fecha = DateTime.Today;
            bitacora.Hora = TimeSpan.Parse((DateTime.Now.ToString("HH:mm:ss")));
            bitacora.Producto = producto.Nombre;
            bitacora.Cantidad = producto.Cantidad;
            bitacora.Transaccion = "ALTA";

            _ = new BitacorasController(_context).agregarBitacora(bitacora);
        }

        private void bajaProductoBitacora(Producto producto)
        {
            Bitacora bitacora = new Bitacora();

            bitacora.Fecha = DateTime.Today;
            bitacora.Hora = TimeSpan.Parse((DateTime.Now.ToString("HH:mm:ss")));
            bitacora.Producto = producto.Nombre;
            bitacora.Cantidad = producto.Cantidad;
            bitacora.Transaccion = "BAJA";

            _ = new BitacorasController(_context).agregarBitacora(bitacora);
        }

        private async void entradaSalidaProducto(int id, Producto newProd)
        {
            var currentProd = await _context.Productos.FindAsync(id);
            Bitacora bitacora = new Bitacora();

            bitacora.Fecha = DateTime.Today;
            bitacora.Hora = TimeSpan.Parse((DateTime.Now.ToString("HH:mm:ss")));
            bitacora.Producto = newProd.Nombre;

            if (!(currentProd == null))
            {
                if(currentProd.Cantidad > newProd.Cantidad)
                {
                    bitacora.Cantidad = currentProd.Cantidad - newProd.Cantidad;
                    bitacora.Transaccion = "SALIDA";

                    _ = new BitacorasController(_context).agregarBitacora(bitacora);
                }
                else if(currentProd.Cantidad < newProd.Cantidad)
                {
                    bitacora.Cantidad = newProd.Cantidad - currentProd.Cantidad;
                    bitacora.Transaccion = "ENTRADA";

                    _ = new BitacorasController(_context).agregarBitacora(bitacora);
                }
            }
        }
    }
}
