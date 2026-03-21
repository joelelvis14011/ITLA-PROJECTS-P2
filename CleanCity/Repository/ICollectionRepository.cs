using CleanCity.Domain.Entities;

namespace CleanCity.Domain.Repository
{
    public interface ICollectionRepository
    {
        Task<Collection?> GetAsync(int id);
        Task<IEnumerable<Collection>> GetAllAsync();
        Task CreateAsync(Collection collection);
        Task UpdateAsync(Collection collection);
        Task DeleteAsync(int id);
    }
}
