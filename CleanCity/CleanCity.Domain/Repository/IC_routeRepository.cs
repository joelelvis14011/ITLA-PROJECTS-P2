using CleanCity.Domain.Entities;

namespace CleanCity.Domain.Repository
{
    public interface IC_RouteRepository
    {
        Task<C_route?> GetAsync(int id);
        Task<IEnumerable<C_route>> GetAllAsync();
        Task CreateAsync(C_route route);
        Task UpdateAsync(C_route route);
        Task DeleteAsync(int id);
    }
}