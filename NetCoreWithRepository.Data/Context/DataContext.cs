using Microsoft.EntityFrameworkCore;
using NetCoreWithRepository.Data.Entities;

namespace NetCoreWithRepository.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
