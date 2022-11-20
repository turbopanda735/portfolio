using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieProject.Models;

namespace movieProject.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewModelsController : ControllerBase
    {
        private readonly ReviewContext _context;

        public ReviewModelsController(ReviewContext context)
        {
            _context = context;
        }

        // GET: api/ReviewModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewModel>>> GetReviews()
        {
          if (_context.Reviews == null)
          {
              return NotFound();
          }
            return await _context.Reviews.ToListAsync();
        }

        // GET: api/ReviewModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewModel>> GetReviewModel(int id)
        {
          if (_context.Reviews == null)
          {
              return NotFound();
          }
            var reviewModel = await _context.Reviews.FindAsync(id);

            if (reviewModel == null)
            {
                return NotFound();
            }

            return reviewModel;
        }

        // PUT: api/ReviewModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviewModel(int id, ReviewModel reviewModel)
        {
            if (id != reviewModel.ReviewId)
            {
                return BadRequest();
            }

            _context.Entry(reviewModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewModelExists(id))
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

        // POST: api/ReviewModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReviewModel>> PostReviewModel(ReviewModel reviewModel)
        {
          if (_context.Reviews == null)
          {
              return Problem("Entity set 'ReviewContext.Reviews'  is null.");
          }
            _context.Reviews.Add(reviewModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReviewModel", new { id = reviewModel.ReviewId }, reviewModel);
        }

        // DELETE: api/ReviewModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewModel(int id)
        {
            if (_context.Reviews == null)
            {
                return NotFound();
            }
            var reviewModel = await _context.Reviews.FindAsync(id);
            if (reviewModel == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(reviewModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewModelExists(int id)
        {
            return (_context.Reviews?.Any(e => e.ReviewId == id)).GetValueOrDefault();
        }
    }
}
