using CleanCity.Domain.Entities;
using CleanCity.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CleanCityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperatorController : ControllerBase
    {
        private readonly IOperatorRepository _repository;

        public OperatorController(IOperatorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _repository.GetAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Operator op)
        {
            await _repository.CreateAsync(op);
            return CreatedAtAction(nameof(Get), new { id = op.Id }, op);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Operator op)
        {
            var existing = await _repository.GetAsync(id);
            if (existing == null) return NotFound();

            existing.Name = op.Name;
            existing.Position = op.Position;
            existing.IsActive = op.IsActive;

            await _repository.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var op = await _repository.GetAsync(id);
            if (op == null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}