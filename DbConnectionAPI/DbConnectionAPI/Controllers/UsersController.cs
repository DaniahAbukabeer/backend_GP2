using DbConnectionAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace DbConnectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //hassing the user passowrd before adding to the database!
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }


        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();

        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegistrationDto userDto)
        {
            //Console.WriteLine($"Received data: {JsonConvert.SerializeObject(userDto)}");
            Console.WriteLine("-----------------------HEELOOWW FROM REGISTER ENDPOINT-------------------------");
            if (userDto == null)
            {
                return BadRequest("Invalid registration data.");    
            }

            if (string.IsNullOrEmpty(userDto.Username) || string.IsNullOrEmpty(userDto.Phonenumber) || string.IsNullOrEmpty(userDto.Password))
            {
                return BadRequest("Username, phonenumber, and password are required.");
            }

            //userDto.Password = HashPassword(userDto.Password);
            var user = new User
            {
                UserName= userDto.Username,
                PhoneNumber = userDto.Phonenumber,
                Password= userDto.Password,
                Longitude = 0,
                Latitude = 0,
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(new { Message = "User registerd successfully."});




        }

        // GET: api/Users/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetUser(int Id)
        { 
            var user = await _context.Users.FindAsync(Id);
            if (user == null)
            { 
                return NotFound();
            }

            return user;

        }

        //signup (register a new user)
        // Post: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user) {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { Id = user.Id }, user);
        
        }

        // PUT: api/Users/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutUser(int Id, User user)
        { 
            if(Id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(await GetUser(Id) == null)
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

        // DELETE: api/Users/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var user = await _context.Users.FindAsync(Id);
            if(user == null) { return NotFound(); }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        
        }




    }
}
