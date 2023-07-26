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
    public class FoodTypesController : ControllerBase
    {
        private readonly FoodContext _context;

        public FoodTypesController(FoodContext context)
        {
            _context = context;
        }

        // GET: api/FoodTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodType>>> GetFoodTypes()
        {
          if (_context.FoodTypes == null)
          {
              return NotFound();
          }
            return await _context.FoodTypes.ToListAsync();
        }

        // GET: api/FoodTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodType>> GetFoodType(int id)
        {
          if (_context.FoodTypes == null)
          {
              return NotFound();
          }
            var foodType = await _context.FoodTypes.FindAsync(id);

            if (foodType == null)
            {
                return NotFound();
            }

            return foodType;
        }

        // PUT: api/FoodTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodType(int id, FoodType foodType)
        {
            if (id != foodType.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(foodType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodTypeExists(id))
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

        // POST: api/FoodTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodType>> PostFoodType(FoodType foodType)
        {
          if (_context.FoodTypes == null)
          {
              return Problem("Entity set 'FoodContext.FoodTypes'  is null.");
          }
            _context.FoodTypes.Add(foodType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FoodTypeExists(foodType.TypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFoodType", new { id = foodType.TypeId }, foodType);
        }

        // DELETE: api/FoodTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodType(int id)
        {
            if (_context.FoodTypes == null)
            {
                return NotFound();
            }
            var foodType = await _context.FoodTypes.FindAsync(id);
            if (foodType == null)
            {
                return NotFound();
            }

            _context.FoodTypes.Remove(foodType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodTypeExists(int id)
        {
            return (_context.FoodTypes?.Any(e => e.TypeId == id)).GetValueOrDefault();
        }
    }
}
