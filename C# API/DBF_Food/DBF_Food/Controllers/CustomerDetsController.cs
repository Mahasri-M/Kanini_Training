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
    public class CustomerDetsController : ControllerBase
    {
        private readonly FoodContext _context;

        public CustomerDetsController(FoodContext context)
        {
            _context = context;
        }

        // GET: api/CustomerDets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDet>>> GetCustomerDets()
        {
          if (_context.CustomerDets == null)
          {
              return NotFound();
          }
            return await _context.CustomerDets.ToListAsync();
        }

        // GET: api/CustomerDets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDet>> GetCustomerDet(int id)
        {
          if (_context.CustomerDets == null)
          {
              return NotFound();
          }
            var customerDet = await _context.CustomerDets.FindAsync(id);

            if (customerDet == null)
            {
                return NotFound();
            }

            return customerDet;
        }

        // PUT: api/CustomerDets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDet(int id, CustomerDet customerDet)
        {
            if (id != customerDet.MobNum)
            {
                return BadRequest();
            }

            _context.Entry(customerDet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDetExists(id))
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

        // POST: api/CustomerDets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerDet>> PostCustomerDet(CustomerDet customerDet)
        {
          if (_context.CustomerDets == null)
          {
              return Problem("Entity set 'FoodContext.CustomerDets'  is null.");
          }
            _context.CustomerDets.Add(customerDet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerDetExists(customerDet.MobNum))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerDet", new { id = customerDet.MobNum }, customerDet);
        }

        // DELETE: api/CustomerDets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDet(int id)
        {
            if (_context.CustomerDets == null)
            {
                return NotFound();
            }
            var customerDet = await _context.CustomerDets.FindAsync(id);
            if (customerDet == null)
            {
                return NotFound();
            }

            _context.CustomerDets.Remove(customerDet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerDetExists(int id)
        {
            return (_context.CustomerDets?.Any(e => e.MobNum == id)).GetValueOrDefault();
        }
    }
}
