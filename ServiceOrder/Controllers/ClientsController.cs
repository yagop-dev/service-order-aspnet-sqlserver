using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using ServiceOrder.Data;
using ServiceOrder.DTOs;
using ServiceOrder.Entities;

namespace ServiceOrder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ClientsController : ControllerBase
    {
        //Reference to the database context
        private readonly SystemDbContext _db;
        public ClientsController(SystemDbContext db)
        {
            _db = db;
        }

        //GET api/clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            //await the query to get all clients without tracking changes
            var list = await _db.Clients.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        //GET api/clients/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Client>> GetById(int id)
        {
            //Find the client by id and await the result
            var client = await _db.Clients.FindAsync(id);
            return client != null ? Ok(client) : NotFound();
        }

        //POST api/clients
        [HttpPost]
        public async Task<ActionResult<Client>> Create([FromBody] ClientCreateDto dto)
        {
            //Client creation DTO for safety, flexibility and optimization
            var client = new Client
            {
                Name = dto.Name,
                Telephone = dto.Telephone,
                Email = dto.Email
            };

            //Save the new client to the database
            _db.Clients.Add(client);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
        }

        //PUT api/clients/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteUpdateDto dto)
        {   
            //Find the client by id
            var client = await _db.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            //Update the permitted fields
            client.Name = !string.IsNullOrWhiteSpace(dto.Name) ? dto.Name : client.Name;
            client.Telephone = !string.IsNullOrWhiteSpace(dto.Telephone) ? dto.Telephone : client.Telephone;
            client.Email = !string.IsNullOrWhiteSpace(dto.Email) ? dto.Email : client.Email;

            //Save the changes to the database
            await _db.SaveChangesAsync();
            return NoContent();
        }

        //DELETE api/clients/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            //Find the client by id
            var client = await _db.Clients.FindAsync(id);
            if (client is null)
            {
                return NotFound();
            }

            //Remove the client from the database
            _db.Clients.Remove(client);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
