using AccountsMicroservice.Models;
using AccountsMicroservice.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AccountsMicroservice.Controllers 
{
[ApiController]
[Route("api/cuentas")]
public class AccountsController : ControllerBase
{
        private readonly IRepository<Account> _repository;

        public AccountsController(IRepository<Account> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _repository.GetByIdAsync(id);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public async Task<ActionResult> PostAccount(Account account)
        {
            await _repository.AddAsync(account);
            return CreatedAtAction(nameof(GetAccount), new { id = account.Number }, account);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAccount(string id, Account account)
        {
            if (id != account.Number) return BadRequest();
            await _repository.UpdateAsync(account);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAccounts(int id, [FromBody] JsonPatchDocument<Account> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var account = await _repository.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(account);

            if (!TryValidateModel(account))
            {
                return BadRequest(ModelState);
            }

            await _repository.UpdateAsync(account);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}