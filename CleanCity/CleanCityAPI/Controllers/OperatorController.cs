using CleanCity.Application.Contract;
using CleanCity.Application.Dtos.Operator;
using Microsoft.AspNetCore.Mvc;

namespace CleanCityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperatorController : ControllerBase
    {
        private readonly IOperatorService _service;

        public OperatorController(IOperatorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OperatorCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OperatorUpdateDto dto)
        {
            dto.Id = id;
            var result = await _service.UpdateAsync(dto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result.Message);
        }
    }
}