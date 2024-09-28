using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AgrotoolsMaps.Infra.EntityFramework
{
    public class GlobalAccountDbContext : DbContext
    {
        public GlobalAccountDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}