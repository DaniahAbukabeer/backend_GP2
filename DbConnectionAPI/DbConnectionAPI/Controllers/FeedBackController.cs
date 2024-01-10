using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbConnectionAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DbConnectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeedBackController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedBack>>> GetFeedBacks()
        {
            return await _context.FeedBacks.ToListAsync();
        }

        [HttpGet("{UserId}/{PharmacyId}")]
        public async Task<ActionResult<FeedBack>> GetFeedBack(int UserId, int PharmacyId)
        {
            var feedBack = await _context.FeedBacks.FindAsync(UserId, PharmacyId);
            if (feedBack == null)
            {
                return NotFound();
            }

            return feedBack;
        }

        [HttpPost]
        public async Task<ActionResult<FeedBack>> PostFeedBack(FeedBack feedBack)
        {
            _context.FeedBacks.Add(feedBack);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedBack", new { UserId = feedBack.UserId, PharmacyId = feedBack.PharmacyId }, feedBack);
        }

        [HttpPut("{UserId}/{PharmacyId}")]
        public async Task<IActionResult> PutFeedBack(int UserId, int PharmacyId, FeedBack feedback)
        {
            if (UserId != feedback.UserId || PharmacyId != feedback.PharmacyId)
            {
                return BadRequest();
            }

            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (await GetFeedBack(UserId, PharmacyId) == null)
                    return NotFound();
                else
                    throw;
            }

            return NoContent();

        }

        [HttpDelete("{UserId}/{PharmacyId}")]
        public async Task<IActionResult> DeleteFeedBack(int UserId, int PharmacyId)
        {
            var feedback = await _context.FeedBacks.FindAsync(UserId, PharmacyId);
            if(feedback==null)
                return NotFound();

            _context.FeedBacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }
    }
}
