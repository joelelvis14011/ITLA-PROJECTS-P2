using Microsoft.EntityFrameworkCore;
using CleanCity.Domain.Entities;

namespace CleanCity.Infrastructure.Context
{
    public class CleanCityDbContext : DbContext
    {
        public CleanCityDbContext(DbContextOptions<CleanCityDbContext> options)
            : base(options)
        {
        }

        public DbSet<C_route> Routes { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Operator> Operators { get; set; }
    }
}