using Microsoft.EntityFrameworkCore;
using Module.A.Domain;

namespace Module.A.Infrastructure
{
    public class ModuleAContext : DbContext
    {
        public ModuleAContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ModuleAEntity>();
        }
    }
}