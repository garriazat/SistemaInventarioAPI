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
    public class CategoriasController : ControllerBase
    {
        private readonly DbSIAPIContext _context;

        public CategoriasController(DbSIAPIContext context)
        {
            _context = context;
        }

        //GET all action
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> obtenerListaCategorias()
        {
          if (_context.Categoria == null)
          {
              return NotFound();
          }
            return await _context.Categoria.ToListAsync();
        }

        //GET by ID action
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Categoria>> obtenerCategoria(int id)
        {
            if (_context.Categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        //GET by Name action
        [HttpGet]
        [Route("{name:alpha}")]
        public Task<ActionResult<Categoria>> obtenerCategoria(string name)
        {
            if (_context.Categoria == null)
            {
                return Task.FromResult<ActionResult<Categoria>>(NotFound());
            }

            var categoria = _context.Categoria.FirstOrDefault(cat => cat.Nombre.ToLower() == name.ToLower());

            if (categoria == null)
            {
                return Task.FromResult<ActionResult<Categoria>>(NotFound());
            }

            return Task.FromResult<ActionResult<Categoria>>(categoria);
        }

        //PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> editarCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Idcategoria)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        //POST action
        [HttpPost]
        public async Task<ActionResult<Categoria>> agregarCategoria(Categoria categoria)
        {
            if (_context.Categoria == null)
            {
                return Problem("Entity set 'DbSIAPIContext.Categoria'  is null.");
            }

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.Idcategoria }, categoria);
        }

        //DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarCategoria(int id)
        {
            if (_context.Categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return (_context.Categoria?.Any(e => e.Idcategoria == id)).GetValueOrDefault();
        }
    }
}
