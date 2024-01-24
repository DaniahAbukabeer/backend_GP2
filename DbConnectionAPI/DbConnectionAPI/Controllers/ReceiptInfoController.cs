using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbConnectionAPI.Models;
using Microsoft.AspNetCore.Http;

namespace DbConnectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptInfoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReceiptInfoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ReceiptInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptInfo>>> GetReceiptInfo()
        { 
            return await _context.ReceiptInfo.ToListAsync();
        }


        // GET: api/ReceiptInfo/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<ReceiptInfo>> GetReceiptInfo(int Id) 
        {
            var receiptInfo = await _context.ReceiptInfo.FindAsync(Id);
            if (receiptInfo == null)
            { 
                return NotFound();
            }

            return receiptInfo;


        }
        //Post: api/ReceiptInfo
        [HttpPost]
        public async Task<ActionResult<ReceiptInfo>> PostReceiptInfo(ReceiptInfo receiptInfo)
        { 
            _context.ReceiptInfo.Add(receiptInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceiptInfo", new { Id = receiptInfo.Id }, receiptInfo);

        
        }

        // Put: api/ReceiptInfo/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutReceiptInfo(int Id, ReceiptInfo receiptInfo)
        {
            if (Id != receiptInfo.Id)
            {
                return BadRequest();    
            }

            _context.Entry(receiptInfo).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            {
                if (await GetReceiptInfo(Id) == null)
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

        //Delete: api/ReceiptInfo/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteReceiptInfo(int Id)
        {
            var receiptInfo = await _context.ReceiptInfo.FindAsync(Id);
            if (receiptInfo == null)
            {
                return NotFound();
            }
            _context.ReceiptInfo.Remove(receiptInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
