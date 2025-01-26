using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;

namespace biblioteka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewAPIController : ControllerBase
    {
        private readonly LibraryContext _context;

        public ReviewAPIController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/ReviewAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewEntity>>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        // GET: api/ReviewAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewEntity>> GetReviewEntity(int id)
        {
            var reviewEntity = await _context.Reviews.FindAsync(id);

            if (reviewEntity == null)
            {
                return NotFound();
            }

            return reviewEntity;
        }

        // PUT: api/ReviewAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviewEntity(int id, ReviewEntity reviewEntity)
        {
            if (id != reviewEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(reviewEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewEntityExists(id))
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

        // POST: api/ReviewAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReviewEntity>> PostReviewEntity(ReviewEntity reviewEntity)
        {
            _context.Reviews.Add(reviewEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReviewEntity", new { id = reviewEntity.Id }, reviewEntity);
        }

        // DELETE: api/ReviewAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewEntity(int id)
        {
            var reviewEntity = await _context.Reviews.FindAsync(id);
            if (reviewEntity == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(reviewEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewEntityExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
