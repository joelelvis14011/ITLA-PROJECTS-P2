using CleanCity.Domain.Entities;
using CleanCity.Domain.Repository;
using CleanCityAPI.Models.DTOs;
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
            var operators = await _repository.GetAllAsync();
            var result = operators.Select(x => new OperatorReadDto
            {
                Id = x.Id,
                Name = x.Name,
                Position = x.Position,
                IsActive = x.IsActive
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var op = await _repository.GetAsync(id);
            if (op == null) return NotFound();

            var dto = new OperatorReadDto
            {
                Id = op.Id,
                Name = op.Name,
                Position = op.Position,
                IsActive = op.IsActive
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OperatorCreateDto dto)
        {
            var op = new Operator
            {
                Name = dto.Name,
                Position = dto.Position,
                IsActive = dto.IsActive
            };
            await _repository.CreateAsync(op);
            return CreatedAtAction(nameof(Get), new { id = op.Id }, op);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OperatorUpdateDto dto)
        {
            var op = await _repository.GetAsync(id);
            if (op == null) return NotFound();

            op.Name = dto.Name;
            op.Position = dto.Position;
            op.IsActive = dto.IsActive;

            await _repository.UpdateAsync(op);
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