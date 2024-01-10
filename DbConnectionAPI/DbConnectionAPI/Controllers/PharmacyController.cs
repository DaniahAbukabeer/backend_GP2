using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DbConnectionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DbConnectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PharmacyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pharmacy>>> GetPharmacys()
        { 
            return await _context.pharmacies.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Pharmacy>> GetPharmacy(int Id)
        {
            var pharmacy = await _context.pharmacies.FindAsync(Id);
            if (pharmacy == null)
            { 
                return NotFound();
            }

            return pharmacy;
        }


        [HttpPost]
        public async Task<ActionResult<Pharmacy>> PostPharmacy(Pharmacy pharmacy)
        {
            _context.pharmacies.Add(pharmacy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPharmacy", new { Id = pharmacy.Id }, pharmacy);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutPharmacy(int Id, Pharmacy pharmacy)
        {
            if (Id != pharmacy.Id)
            {
                return BadRequest();
            }

            _context.Entry(pharmacy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await GetPharmacy(Id) == null)
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
        public async Task<IActionResult> DeletePharmacy(int Id)
        {
            var pharmcy = await _context.pharmacies.FindAsync(Id);
            if (pharmcy == null) { return NotFound(); }
            _context.pharmacies.Remove(pharmcy);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
