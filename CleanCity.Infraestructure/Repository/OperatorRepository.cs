using CleanCity.Domain.Entities;
using CleanCity.Domain.Repository;
using CleanCity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanCity.Infrastructure.Repository
{
    public class OperatorRepository : IOperatorRepository
    {
        private readonly CleanCityDbContext _context;

        public OperatorRepository(CleanCityDbContext context)
        {
            _context = context;
        }

        public async Task<Operator?> GetAsync(int id)
            => await _context.Operators.FindAsync(id);

        public async Task<IEnumerable<Operator>> GetAllAsync()
            => await _context.Operators.ToListAsync();

        public async Task CreateAsync(Operator oper)
        {
            _context.Operators.Add(oper);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Operator oper)
        {
            _context.Operators.Update(oper);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var oper = await _context.Operators.FindAsync(id);
            if (oper != null)
            {
                _context.Operators.Remove(oper);
                await _context.SaveChangesAsync();
            }
        }
    }
}