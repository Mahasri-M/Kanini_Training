using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBF_Food.Models;

namespace DBF_Food.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetsController : ControllerBase
    {
        private readonly FoodContext _context;

        public OrderDetsController(FoodContext context)
        {
            _context = context;
        }

        // GET: api/OrderDets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDet>>> GetOrderDets()
        {
          if (_context.OrderDets == null)
          {
              return NotFound();
          }
            return await _context.OrderDets.ToListAsync();
        }

        // GET: api/OrderDets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDet>> GetOrderDet(int id)
        {
          if (_context.OrderDets == null)
          {
              return NotFound();
          }
            var orderDet = await _context.OrderDets.FindAsync(id);

            if (orderDet == null)
            {
                return NotFound();
            }

            return orderDet;
        }

        // PUT: api/OrderDets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDet(int id, OrderDet orderDet)
        {
            if (id != orderDet.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderDet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetExists(id))
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

        // POST: api/OrderDets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDet>> PostOrderDet(OrderDet orderDet)
        {
          if (_context.OrderDets == null)
          {
              return Problem("Entity set 'FoodContext.OrderDets'  is null.");
          }
            _context.OrderDets.Add(orderDet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderDet", new { id = orderDet.OrderId }, orderDet);
        }

        // DELETE: api/OrderDets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDet(int id)
        {
            if (_context.OrderDets == null)
            {
                return NotFound();
            }
            var orderDet = await _context.OrderDets.FindAsync(id);
            if (orderDet == null)
            {
                return NotFound();
            }

            _context.OrderDets.Remove(orderDet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderDetExists(int id)
        {
            return (_context.OrderDets?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
