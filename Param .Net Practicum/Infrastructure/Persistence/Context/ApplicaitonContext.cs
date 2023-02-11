using Microsoft.EntityFrameworkCore;
using Param_.Net_Practicum.Core.Domain.Entities;

namespace Param_.Net_Practicum.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
