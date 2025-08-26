using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceOrder.Data;
using ServiceOrder.Entities;
using System.Threading.Tasks;
using ServiceOrder.DTOs;

namespace ServiceOrder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SystemDbContext _db;
        public AuthController(SystemDbContext db)
        {
            _db = db;
        }


        [HttpPost("register")]
        public async Task<ActionResult<ClientRegisterResponse>> Register([FromBody] ClientCreateDto registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exists = await _db.Clients.AnyAsync(c => c.Email == registerRequest.Email);
            if (exists)
            {
                return Conflict(new {message = "E-mail already registered." });
            }

            var client = new Client
            {
                Name = registerRequest.Name.Trim(),
                Telephone = registerRequest.Telephone.Trim(),
                Email = registerRequest.Email.Trim()
            };

            _db.Clients.Add(client);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Register), new { id = client.Id }, new ClientRegisterResponse
            {
                Id = client.Id,
                Name = client.Name,
                Telephone = client.Telephone,
                Email = client.Email
            });
        }


        public class ClientRegisterResponse()
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public string? Telephone { get; set; }
            public string? Email { get; set; }
        }

        #region Login
        public class LoginRequest()
        {
            public string Email { get; set; } = "";
        }

        public class ClientLoginResponse()
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public string? Telephone { get; set; }
            public string? Email { get; set; }
        }
    

        [HttpPost("login")]
        public async Task<ActionResult<ClientLoginResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            if (string.IsNullOrWhiteSpace(loginRequest.Email))
            {
                return BadRequest("E-mail required");
            }

            var email = loginRequest.Email.Trim().ToLowerInvariant();

            var client = await _db.Clients.AsNoTracking().FirstOrDefaultAsync(c => c.Email.ToLower() == email);

            if(client == null)
            {
                return Unauthorized(new { message = "E-mail not found." });
            }

            return Ok(new ClientLoginResponse
            {
                Id = client.Id,
                Name = client.Name,
                Telephone = client.Telephone,
                Email = client.Email
            });
        }

        #endregion

    }
}
