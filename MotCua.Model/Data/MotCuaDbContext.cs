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
        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Attach> Attaches { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
