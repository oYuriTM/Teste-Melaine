using CRUD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infra.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }            
        public DbSet<Client> Clients { get; set; }

    }
}
