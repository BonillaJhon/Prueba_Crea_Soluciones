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
    public class TiendasController : ControllerBase
    {
        private readonly WebApplication24Context _context;

        public TiendasController(WebApplication24Context context)
        {
            _context = context;
        }

        // GET: api/Tiendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tienda>>> GetTienda()
        {
            return await _context.Tienda.ToListAsync();
        }

        // GET: api/Tiendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tienda>> GetTienda(int id)
        {
            var tienda = await _context.Tienda.FindAsync(id);

            if (tienda == null)
            {
                return NotFound();
            }

            return tienda;
        }

        // PUT: api/Tiendas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTienda(int id, Tienda tienda)
        {
            if (id != tienda.ID)
            {
                return BadRequest();
            }

            _context.Entry(tienda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiendaExists(id))
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

        // POST: api/Tiendas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tienda>> PostTienda(Tienda tienda)
        {
            _context.Tienda.Add(tienda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTienda", new { id = tienda.ID }, tienda);
        }

        // DELETE: api/Tiendas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tienda>> DeleteTienda(int id)
        {
            var tienda = await _context.Tienda.FindAsync(id);
            if (tienda == null)
            {
                return NotFound();
            }

            _context.Tienda.Remove(tienda);
            await _context.SaveChangesAsync();

            return tienda;
        }

        private bool TiendaExists(int id)
        {
            return _context.Tienda.Any(e => e.ID == id);
        }
    }
}
