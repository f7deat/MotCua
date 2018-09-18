using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MotCua.Model.Data
{
    public class MotCuaDbContext : DbContext
    {
        public MotCuaDbContext() : base("MotCuaDbContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
