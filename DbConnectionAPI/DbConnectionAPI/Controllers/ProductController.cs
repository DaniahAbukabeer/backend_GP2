using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbConnectionAPI.Models;
using Microsoft.AspNetCore.Http;

namespace DbConnectionAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        //Get: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() { 
            return  await _context.Products.ToListAsync();
        }

        //Get: api/Product/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        { 
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        { 
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduct", new { Id = product.Id }, product);

        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutProduct(int Id, Product product)
        {
            if (Id != product.Id)
            { 
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await GetProduct(Id) == null)
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        { 
            var product = await _context.Products.FindAsync(Id);
            if (product == null) { return NotFound();}
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
