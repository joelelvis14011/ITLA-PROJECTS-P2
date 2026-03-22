using CleanCity.Domain.Entities;
using CleanCity.Domain.Repository;
using CleanCity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanCity.Infrastructure.Repository
{
    public class C_routeRepository : IC_RouteRepository
    {
        private readonly CleanCityDbContext _context;

        public C_routeRepository(CleanCityDbContext context)
        {
            _context = context;
        }

        public async Task<C_route?> GetAsync(int id)
            => await _context.Routes.FindAsync(id);

        public async Task<IEnumerable<C_route>> GetAllAsync()
            => await _context.Routes.ToListAsync();

        public async Task CreateAsync(C_route route)
        {
            _context.Routes.Add(route);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(C_route route)
        {
            _context.Routes.Update(route);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route != null)
            {
                _context.Routes.Remove(route);
                await _context.SaveChangesAsync();
            }
        }
    }
}