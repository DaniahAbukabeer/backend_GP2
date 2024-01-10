using Microsoft.AspNetCore.Mvc;
using DbConnectionAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace DbConnectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProduct>>> GetUserProducts()
        {
            return await _context.UserProducts.ToListAsync();

        }

        // GET: api/UsersProducts/1/2
        [HttpGet("{UserId}/{ProductId}")]
        public async Task<ActionResult<UserProduct>> GetUserProduct(int UserId, int ProductId)
        {
            var userProducts = await _context.UserProducts.FindAsync(UserId, ProductId);
            if (userProducts == null)
            {
                return NotFound();

            }

            return userProducts;
        }


        //post: api/UsersProducts
        [HttpPost]
        public async Task<ActionResult<UserProduct>> PostUserProducts(UserProduct userProduct)
        {
            _context.UserProducts.Add(userProduct);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUserProduct", new { UserId = userProduct.UserId, ProductId = userProduct.ProductId }, userProduct);

        }

        // PUT: api/UserProducts/1/2
        [HttpPut("{UserId}/{ProductId}")]
        public async Task<IActionResult> PutUserProduct(int UserId, int ProductId, UserProduct userProduct)
        {
            if (UserId != userProduct.UserId || ProductId != userProduct.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(userProduct).State = EntityState.Modified;

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await GetUserProduct(UserId, ProductId) == null)
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

        //DELETE: api/UsersProducts/1/2
        [HttpDelete("{UserId}/{ProductId}")]
        public async Task<IActionResult> DeleteUsersProduct(int UserId, int ProductId)
        {
            var userProduct = await _context.UserProducts.FindAsync(UserId,ProductId);
            if (userProduct == null)
            {
                return NotFound();
            }

            _context.UserProducts.Remove(userProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        
        }

    }
}
