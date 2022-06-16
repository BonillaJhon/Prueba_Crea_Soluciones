using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication24.Data;
using WebApplication24.Models;

namespace WebApplication24.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly WebApplication24Context _context;

        public ProductosController(WebApplication24Context context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProductos(string id)
        {
            var productos = await _context.Productos.FindAsync(id);

            if (productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductos(string id, Productos productos)
        {
            if (id != productos.Nombre)
            {
                return BadRequest();
            }

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Productos>> PostProductos(Productos productos)
        {
            _context.Productos.Add(productos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductosExists(productos.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductos", new { id = productos.Nombre }, productos);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Productos>> DeleteProductos(string id)
        {
            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(productos);
            await _context.SaveChangesAsync();

            return productos;
        }

        private bool ProductosExists(string id)
        {
            return _context.Productos.Any(e => e.Nombre == id);
        }
    }
}
