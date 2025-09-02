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

        #region Client register
        [HttpPost("client-register")]
        public async Task<ActionResult<ClientRegisterResponse>> ClientRegister([FromBody] ClientCreateDto registerRequest)
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
            return CreatedAtAction(nameof(ClientRegister), new { id = client.Id }, new ClientRegisterResponse
            {
                Id = client.Id,
                Name = client.Name,
                Telephone = client.Telephone,
                Email = client.Email
            });
        }
        #endregion

        #region Client Login
        [HttpPost("client-login")]
        public async Task<ActionResult<ClientLoginResponse>> ClientLogin([FromBody] LoginRequest loginRequest)
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


        [HttpPost("technician-register")]
        public async Task<ActionResult<TechnicianRegisterResponse>> TechnicianRegister([FromBody] TechnicianCreateDto registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exists = await _db.Technicians.AnyAsync(t => t.Email == registerRequest.Email || t.Registration == registerRequest.Registration);
            if (exists)
            {
                return Conflict(new { message = "E-mail/Registration " +
                    "already registered." });
            }

            var technician = new Technician
            {
                Name = registerRequest.Name.Trim(),
                Email = registerRequest.Email.Trim(),
                Registration = registerRequest.Registration
            };

            _db.Technicians.Add(technician);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(TechnicianRegister), new { id = technician.Id }, new TechnicianRegisterResponse()
            {
                Id = technician.Id,
                Name = technician.Name,
                Email = technician.Email,
                Registration = technician.Registration
            });
        }
    }
}
