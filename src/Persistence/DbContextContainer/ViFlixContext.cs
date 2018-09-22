using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.DbContextContainer
{
    public class ViFlixContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public ViFlixContext(DbContextOptions<ViFlixContext> options)
            : base(options)
        {
        }
    }
}