using CleanCity.Domain.Entities;
using CleanCity.Domain.Repository;
using CleanCity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanCity.Infrastructure.Repository
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly CleanCityDbContext _context;

        public CollectionRepository(CleanCityDbContext context)
        {
            _context = context;
        }

        public async Task<Collection?> GetAsync(int id)
            => await _context.Collections.FindAsync(id);

        public async Task<IEnumerable<Collection>> GetAllAsync()
            => await _context.Collections.ToListAsync();

        public async Task CreateAsync(Collection collection)
        {
            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Collection collection)
        {
            _context.Collections.Update(collection);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var collection = await _context.Collections.FindAsync(id);
            if (collection != null)
            {
                _context.Collections.Remove(collection);
                await _context.SaveChangesAsync();
            }
        }
    }
}