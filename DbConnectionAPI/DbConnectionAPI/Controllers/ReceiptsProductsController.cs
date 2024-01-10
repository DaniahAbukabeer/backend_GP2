using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbConnectionAPI.Models;

namespace DbConnectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReceiptsProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptsProducts>>> GetReceiptsProducts()
        { 
            return await _context.ReceiptsProducts.ToListAsync();
        }

        [HttpGet("{Id}/{ProductId}")]
        public async Task<ActionResult<ReceiptsProducts>> GetReceiptsProduct(int Id, int ProductId)
        {
            var receiptsProducts = await _context.ReceiptsProducts.FindAsync(Id, ProductId);
            if(receiptsProducts == null)
                return NotFound();

            return receiptsProducts;
        }


        [HttpPost("{Id}/{ProductId}")]
        public async Task<IActionResult> PostReceiptsProducts(ReceiptsProducts receiptsProducts)
        { 
            _context.ReceiptsProducts.Add(receiptsProducts);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetReceiptsProducts", new { Id = receiptsProducts.Id, ProductId = receiptsProducts.ProductId }, receiptsProducts);
        }

        [HttpPut("{Id}/{ProductId}")]
        public async Task<IActionResult> PutReceiptsProducts(int Id, int ProductId, ReceiptsProducts receiptsProducts)
        {
            if (Id != receiptsProducts.Id || ProductId != receiptsProducts.ProductId)
                return BadRequest();

            _context.Entry(receiptsProducts).State = EntityState.Modified;

            try { 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await GetReceiptsProduct(Id, ProductId) == null)
                    return NotFound();
                else
                    throw;

            }
            return NoContent();
        }


        [HttpDelete("{Id}/{ProductId}")]
        public async Task<IActionResult> DeleteReceiptsProducts(int Id, int ProductId)
        {
            var receiptsProducts = await _context.ReceiptsProducts.FindAsync(Id, ProductId);
            if (receiptsProducts == null)
                return NotFound();
            _context.ReceiptsProducts.Remove(receiptsProducts);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
