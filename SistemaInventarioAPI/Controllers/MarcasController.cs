using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioAPI.Models;

namespace SistemaInventarioAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcasController : ControllerBase
    {
        private readonly DbSIAPIContext _context;

        public MarcasController(DbSIAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> obtenerListaMarcas()
        {
            if(_context.Marcas == null) 
            { 
                return NotFound(); 
            }

            IEnumerable<Marca> lstMarcas = await _context.Marcas.ToListAsync();
            return Ok(lstMarcas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> obtenerMarca(int id)
        {
            if (_context.Marcas == null)
            {
                return NotFound();
            }

            var mark = await _context.Marcas.FindAsync(id);

            if (mark == null)
            {
                return NotFound();
            }

            return Ok(mark);
        }

        [HttpPost]
        public async Task<IActionResult> agregarMarca([FromBody] Marca mark)
        {
            if (_context.Marcas == null)
            {
                return NotFound();
            }

            await _context.Marcas.AddAsync(mark);
            await _context.SaveChangesAsync();

            return Ok(mark);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarMarca(int id)
        {
            if (_context.Marcas == null)
            {
                return NotFound();
            }

            var mark = await _context.Marcas.FindAsync(id);

            if (mark == null)
            {
                return NotFound();
            }

            _context.Marcas.Remove(mark);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
