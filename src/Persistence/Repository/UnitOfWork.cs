using System;
using System.Threading.Tasks;
using Common.Data;
using Common.Data.Repository;
using Persistence.DbContextContainer;
using Persistence.Repository.EFImplementation;

namespace Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ViFlixContext _context;

        public UnitOfWork(ViFlixContext context)
        {
            _context = context ?? throw new NullReferenceException("DbContext cannot be null");

            Customers = new CustomerRepository(_context);
            Movies = new MovieRepository(_context);
            MembershipTypes = new MembershipTypeRepository(_context);
            Rentals = new RentalRepository(_context);
        }

        public ICustomerRepository Customers { get; }

        public IMovieRepository Movies { get; }

        public IMembershipTypeRepository MembershipTypes { get; }

        public IRentalRepository Rentals { get; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}