using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceOrder.Data;
using ServiceOrder.DTOs;
using ServiceOrder.Entities;

namespace ServiceOrder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechniciansController : ControllerBase
    {
        private readonly SystemDbContext _db;
        public TechniciansController (SystemDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Technician>>> GetAll()
        {
            var list = await _db.Technicians.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Technician>> GetById(int id)
        {
            var technician = await _db.Technicians.FindAsync(id);
            return technician != null ? Ok(technician) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Technician>> Create([FromBody] TechnicianCreateDto dto)
        {
            var technician = new Technician
            {
                Name = dto.Name
            };

            _db.Technicians.Add(technician);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = technician.Id }, technician);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TechnicianCreateDto dto)
        {
            var technician = await _db.Technicians.FindAsync(id);
            if(technician is null)
            {
                return NotFound();
            }
            technician.Name = dto.Name;
            await _db.SaveChangesAsync();
            return Ok(technician);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete (int id)
        {
            var technician = await _db.Technicians.FindAsync(id);
            if (technician is null)
            {
                return NotFound();
            }
            _db.Technicians.Remove(technician);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
