using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceOrder.Data;
using ServiceOrder.DTOs;
using ServiceOrder.Entities;
using System.Reflection;

namespace ServiceOrder.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ServiceOrderController : ControllerBase
    {
        private readonly SystemDbContext _db;
        public ServiceOrderController(SystemDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceOrders>>> GetAll([FromQuery] string? status, [FromQuery] int? clientId, [FromQuery] string? clientName, [FromQuery] int? technicianId, [FromQuery] string? technicianName)
        {
            var query = _db.ServiceOrders.AsNoTracking().Include(so => so.Client).Include(so => so.Technician).AsQueryable();

            //Apply filters based on query parameters
            query = !string.IsNullOrWhiteSpace(status) ? query.Where(so => so.Status == status) : query;
            query = clientId.HasValue ? query.Where(so => so.ClientId == clientId.Value) : query;
            query = !string.IsNullOrWhiteSpace(clientName) ? query.Where(so => so.Client.Name == clientName) : query;
            query = technicianId.HasValue ? query.Where(so => so.TechnicianId == technicianId.Value) : query;
            query = !string.IsNullOrWhiteSpace(technicianName) ? query.Where(so => so.Technician.Name == technicianName) : query;

            var so = await query.ToListAsync();

            var dto = so.Select(so => new ServiceOrderReadDto
            {
                Id = so.Id,
                Title = so.Title,
                Description = so.Description,
                Status = so.Status,
                CreatedDate = so.CreatedDate,
                Client = new ClientDto { Id = so.Client.Id, Name = so.Client.Name },
                Technician = so.Technician == null ? null : new TechnicianDto { Id = so.Technician.Id, Name = so.Technician.Name }
            });

            return Ok(dto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceOrders>> GetById(int id)
        {
            var so = await _db.ServiceOrders.Include(so => so.Client).Include(so => so.Technician).AsNoTracking().FirstOrDefaultAsync(so => so.Id == id);
            if(so == null)
            {
                return NotFound();
            }

            var dto = new ServiceOrderReadDto
            {
                Id = so.Id,
                Title = so.Title,
                Description = so.Description,
                Status = so.Status,
                CreatedDate = so.CreatedDate,
                Client = new ClientDto { Id = so.Client.Id, Name = so.Client.Name },
                Technician = so.Technician == null ? null : new TechnicianDto { Id = so.Technician.Id, Name = so.Technician.Name }
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceOrders>> Create([FromBody] ServiceOrderCreateDto dto)
        {
            var clientExists = await _db.Clients.AnyAsync(c => c.Id == dto.ClientId);
            if (!clientExists)
            {
                return BadRequest("Client " + dto.ClientId + " does not exist.");
            }

            if (dto.TechnicianId.HasValue)
            {
                var technicianExists = await _db.Technicians.AnyAsync(t => t.Id == dto.TechnicianId.Value);
                if (!technicianExists)
                {
                    return BadRequest("Technician " + dto.TechnicianId + " does not exist.");
                }
            }

            var so = new ServiceOrders
            {
                ClientId = dto.ClientId,
                TechnicianId = dto.TechnicianId,
                Title = dto.Title,
                Description = dto.Description,
                CreatedDate = DateTime.UtcNow,
                Status = "Pending"
            };
            _db.ServiceOrders.Add(so);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = so.Id }, so);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceOrderUpdateDto dto)
        {
            var so = await _db.ServiceOrders.FindAsync(id);
            if (so == null)
            {
                return NotFound();
            }

            if (dto.TechnicianId.HasValue)
            {
                var technicianExists = await _db.Technicians.AnyAsync(t => t.Id == dto.TechnicianId.Value);
                if(technicianExists)
                {
                    so.TechnicianId = dto.TechnicianId;
                }
            }
            else
            {
                so.TechnicianId = so.TechnicianId;
            }

            if (dto.Description != "string")
            {
                so.Description = !string.IsNullOrWhiteSpace(dto.Description) ? dto.Description : so.Description;
            }
            else
            {
                so.Description = so.Description;
            }

            if (dto.Status != "string")
            {
                so.Status = !string.IsNullOrWhiteSpace(dto.Status) ? dto.Status : so.Status;
            }
            else
            {
                so.Status = so.Status;
            }

            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var so = await _db.ServiceOrders.FindAsync(id);
            if (so == null)
            {
                return NotFound();
            }
            _db.ServiceOrders.Remove(so);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
