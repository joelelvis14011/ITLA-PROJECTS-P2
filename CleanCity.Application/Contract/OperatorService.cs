using CleanCity.Application.Contract;
using CleanCity.Application.Core;
using CleanCity.Application.Dtos.Operator;
using CleanCity.Domain.Entities;
using CleanCity.Domain.Repository;

namespace CleanCity.Application.Service
{
    public class OperatorService : IOperatorService
    {
        private readonly IOperatorRepository _repository;

        public OperatorService(IOperatorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OperatorReadDto>> GetAllAsync()
        {
            var operators = await _repository.GetAllAsync();
            return operators.Select(o => new OperatorReadDto
            {
                Id = o.Id,
                Name = o.Name,
                Position = o.Position,
                IsActive = o.IsActive
            });
        }

        public async Task<OperatorReadDto?> GetAsync(int id)
        {
            var op = await _repository.GetAsync(id);
            if (op == null) return null;

            return new OperatorReadDto
            {
                Id = op.Id,
                Name = op.Name,
                Position = op.Position,
                IsActive = op.IsActive
            };
        }

        public async Task<ServiceResult> CreateAsync(OperatorCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return ServiceResult.Fail("Name is required.");

            if (dto.Name.Length > 100)
                return ServiceResult.Fail("Name cannot exceed 100 characters.");

            if (string.IsNullOrWhiteSpace(dto.Position))
                return ServiceResult.Fail("Position is required.");

            if (dto.Position.Length > 100)
                return ServiceResult.Fail("Position cannot exceed 100 characters.");

            var op = new Operator
            {
                Name = dto.Name,
                Position = dto.Position,
                IsActive = dto.IsActive
            };

            await _repository.CreateAsync(op);
            return ServiceResult.Ok("Operator created successfully.");
        }

        public async Task<ServiceResult> UpdateAsync(OperatorUpdateDto dto)
        {
            if (dto.Id <= 0)
                return ServiceResult.Fail("Invalid ID.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                return ServiceResult.Fail("Name is required.");

            if (dto.Name.Length > 100)
                return ServiceResult.Fail("Name cannot exceed 100 characters.");

            if (string.IsNullOrWhiteSpace(dto.Position))
                return ServiceResult.Fail("Position is required.");

            if (dto.Position.Length > 100)
                return ServiceResult.Fail("Position cannot exceed 100 characters.");

            var op = await _repository.GetAsync(dto.Id);
            if (op == null)
                return ServiceResult.Fail("Operator not found.");

            op.Name = dto.Name;
            op.Position = dto.Position;
            op.IsActive = dto.IsActive;

            await _repository.UpdateAsync(op);
            return ServiceResult.Ok("Operator updated successfully.");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            if (id <= 0)
                return ServiceResult.Fail("Invalid ID.");

            var op = await _repository.GetAsync(id);
            if (op == null)
                return ServiceResult.Fail("Operator not found.");

            await _repository.DeleteAsync(id);
            return ServiceResult.Ok("Operator deleted successfully.");
        }
    }
}