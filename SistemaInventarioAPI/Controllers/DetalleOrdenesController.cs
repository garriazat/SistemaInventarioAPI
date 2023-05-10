using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventarioAPI.Models;

namespace SistemaInventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleOrdenesController : ControllerBase
    {
        private readonly DbSIAPIContext _context;

        public DetalleOrdenesController(DbSIAPIContext context)
        {
            _context = context;
        }

        // GET: api/DetalleOrdenes
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DetalleOrden>>> GetDetalleOrdens()
        //{
        //    if (_context.DetalleOrdens == null)
        //    {
        //        return NotFound();
        //    }

        //    return await _context.DetalleOrdens.ToListAsync();
        //}

        // GET: api/DetalleOrdenes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<DetalleOrden>> GetDetalleOrden(int id)
        //{
        //  if (_context.DetalleOrdens == null)
        //  {
        //      return NotFound();
        //  }
        //    var detalleOrden = await _context.DetalleOrdens.FindAsync(id);

        //    if (detalleOrden == null)
        //    {
        //        return NotFound();
        //    }

        //    return detalleOrden;
        //}

        [HttpGet]
        [Route("{orderID:int}")]
        public async Task<ActionResult<IEnumerable<DetalleOrden>>> obtenerDetalleOrden(int orderID)
        {
            if (_context.DetalleOrdens == null)
            {
                return NotFound();
            }

            return await _context.DetalleOrdens.Where(d => d.Idorden == orderID).ToListAsync();
        }

        // PUT: api/DetalleOrdenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> editarDetalleOrden(int id, DetalleOrden detalleOrden)
        {
            if (id != detalleOrden.IddetalleOrden)
            {
                return BadRequest();
            }

            _context.Entry(detalleOrden).State = EntityState.Modified;

            var producto = await _context.Productos.FindAsync(detalleOrden.Idproducto);
            if (!(producto == null))
            {
                var actual = await _context.DetalleOrdens.FindAsync(id);
                if (!(actual == null))
                {
                    if(actual.Cantidad > detalleOrden.Cantidad)
                    {
                        producto.Cantidad += (actual.Cantidad - detalleOrden.Cantidad);
                        _context.Entry(producto).State = EntityState.Modified;
                    }
                    else if (actual.Cantidad < detalleOrden.Cantidad)
                    {
                        producto.Cantidad -= (detalleOrden.Cantidad - actual.Cantidad);
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
                if (!DetalleOrdenExists(id))
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

        // POST: api/DetalleOrdenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleOrden>> agregarDetalleOrden(DetalleOrden detalleOrden)
        {
          if (_context.DetalleOrdens == null)
          {
              return Problem("Entity set 'DbSIAPIContext.DetalleOrdens'  is null.");
          }
            _context.DetalleOrdens.Add(detalleOrden);

            var producto = await _context.Productos.FindAsync(detalleOrden.Idproducto);
            if (!(producto == null))
            {
                producto.Cantidad -= detalleOrden.Cantidad;
                _context.Entry(producto).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleOrden", new { id = detalleOrden.IddetalleOrden }, detalleOrden);
        }

        // DELETE: api/DetalleOrdenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarDetalleOrden(int id)
        {
            if (_context.DetalleOrdens == null)
            {
                return NotFound();
            }
            var detalleOrden = await _context.DetalleOrdens.FindAsync(id);
            if (detalleOrden == null)
            {
                return NotFound();
            }

            _context.DetalleOrdens.Remove(detalleOrden);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleOrdenExists(int id)
        {
            return (_context.DetalleOrdens?.Any(e => e.IddetalleOrden == id)).GetValueOrDefault();
        }
    }
}
