using ClientsMicroservice.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ClientsMicroservice.Controllers 
{
[ApiController]
[Route("api/clientes")]
public class AccountsController : ControllerBase
{
        private readonly IRepository<Client> _repository;

        public AccountsController(IRepository<Client> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _repository.GetByIdAsync(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> PostClient(Client client)
        {
            await _repository.AddAsync(client);
            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutClient(int id, Client client)
        {
            if (id != client.Id) return BadRequest();
            await _repository.UpdateAsync(client);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchClients(int id, [FromBody] JsonPatchDocument<Client> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var client = await _repository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(client);

            if (!TryValidateModel(client))
            {
                return BadRequest(ModelState);
            }

            await _repository.UpdateAsync(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}