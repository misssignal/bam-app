using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostgresDB;
using PostgresDB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresDB.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly MyDbContext _context;

        public FoodController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFood()
        {
            var foodResult = await _context.sample_table_food.ToListAsync();
            return Ok(foodResult);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(int id)
        {
            var food = await _context.sample_table_food.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

/*        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food foodItem)
        {
            _context.sample_table_food.Add(foodItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFood), new { id = foodItem.id }, foodItem);
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, Food food)
        {
            if (id != food.id)
            {
                return BadRequest();
            }

            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var food = await _context.sample_table_food.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.sample_table_food.Remove(food);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodExists(int id)
        {
            return _context.sample_table_food.Any(e => e.id == id);
        }
    }

}
