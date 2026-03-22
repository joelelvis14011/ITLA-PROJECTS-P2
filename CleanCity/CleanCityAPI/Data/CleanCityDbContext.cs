using Microsoft.EntityFrameworkCore;
using CleanCityAPI.Models.Entities;

namespace CleanCityAPI.Data
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
