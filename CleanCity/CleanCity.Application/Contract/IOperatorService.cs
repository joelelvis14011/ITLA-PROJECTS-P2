using CleanCity.Application.Core;
using CleanCity.Application.Dtos.Operator;

namespace CleanCity.Application.Contract
{
    public interface IOperatorService
    {
        Task<ServiceResult> CreateAsync(OperatorCreateDto dto);
        Task<ServiceResult> UpdateAsync(OperatorUpdateDto dto);
        Task<ServiceResult> DeleteAsync(int id);
        Task<OperatorReadDto?> GetAsync(int id);
        Task<IEnumerable<OperatorReadDto>> GetAllAsync();
    }
}