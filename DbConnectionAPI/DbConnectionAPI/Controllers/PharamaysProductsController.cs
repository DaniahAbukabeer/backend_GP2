using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbConnectionAPI.Models;


namespace DbConnectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharamaysProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PharamaysProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PharamaysProducts>>> GetPharamaysProductss()
        {
            return await _context.PharamaysProducts.ToListAsync();
        }

        [HttpGet("{PharmacyId}/{ProductId}")]
        public async Task<ActionResult<PharamaysProducts>> GetPharamaysProducts(int PharmacyId, int ProductId)
        {
            var pharmacyProduct = await _context.PharamaysProducts.FindAsync(PharmacyId,ProductId);
            if (pharmacyProduct == null)
            {
                return NotFound();
            }
            return pharmacyProduct;
        
        
        }

        [HttpPost]
        public async Task<ActionResult<PharamaysProducts>> PostPharamaysProducts(PharamaysProducts pharamaysProducts)
        { 
            _context.PharamaysProducts.Add(pharamaysProducts);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPharamaysProducts", new { PharmacyId = pharamaysProducts.PharmacyId,ProductId = pharamaysProducts.ProductId }, pharamaysProducts);
        }

        [HttpPut("{PharmacyId}/{ProductId}")]
        public async Task<IActionResult> PutPharamaysProducts(int PharmacyId, int ProductId, PharamaysProducts pharamaysProducts)
        {
            if (PharmacyId != pharamaysProducts.PharmacyId || ProductId != pharamaysProducts.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(pharamaysProducts).State = EntityState.Modified;

            try
            {

                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (await GetPharamaysProducts(PharmacyId, ProductId) == null)
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{PharmacyId}/{ProductId}")]
        public async Task<IActionResult> DeletePharamaysProducts(int PharmacyId, int ProductId)
        {
            var pharmacyproduct = await _context.PharamaysProducts.FindAsync(PharmacyId, ProductId);
            if (pharmacyproduct == null)
                return NotFound();

            _context.PharamaysProducts.Remove(pharmacyproduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
