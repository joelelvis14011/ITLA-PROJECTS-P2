using CleanCity.Domain.Entities;

namespace CleanCity.Domain.Repository
{
    public interface IOperatorRepository
    {
        Task<Operator?> GetAsync(int id);
        Task<IEnumerable<Operator>> GetAllAsync();
        Task CreateAsync(Operator oper);
        Task UpdateAsync(Operator oper);
        Task DeleteAsync(int id);
    }
}