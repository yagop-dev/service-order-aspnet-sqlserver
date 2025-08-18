using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceOrder.Data;
using ServiceOrder.DTOs;
using ServiceOrder.Entities;

namespace ServiceOrder.Controllers
{
    //Easily creation of API REST
    [ApiController]
    //Route for the controller
    [Route("api/[controller]")]

    public class ClientsController : ControllerBase
    {
        //Reference to the database context
        private readonly SystemDbContext _db;
        //Constructor that receives the database context
        public ClientsController(SystemDbContext db)
        {
            _db = db;
        }

        //GET api/clients
        [HttpGet]
        //Async method to get all clients
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            //await the query to get all clients without tracking changes
            var list = await _db.Clients.AsNoTracking().ToListAsync();
            //return the list of clients
            return Ok(list);
        }

        //GET api/clients/{id}
        [HttpGet("{id:int}")]
        //Async method to get a client by id
        public async Task<ActionResult<Client>> GetById(int id)
        {
            //Find the client by id and await the result
            var client = await _db.Clients.FindAsync(id);
            //If the client is found, return it, otherwise return NotFound
            return client is not null ? Ok(client) : NotFound();
        }

        //POST api/clients
        [HttpPost]
        public async Task<ActionResult<Client>> Create([FromBody] ClientCreateDto dto)
        {
            var client = new Client
            {
                Name = dto.Name,
                Telephone = dto.Telephone,
                Email = dto.Email
            };

            _db.Clients.Add(client);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
        }

        //PUT api/clients/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteUpdateDto dto)
        {
            var client = await _db.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            //Update the permited fields
            client.Name = dto.Name;
            client.Telephone = dto.Telephone;
            client.Email = dto.Email;

            await _db.SaveChangesAsync();
            return Ok(client);
        }

        //DELETE api/clients/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _db.Clients.FindAsync(id);
            if (client is null)
            {
                return NotFound();
            }
            _db.Clients.Remove(client);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
