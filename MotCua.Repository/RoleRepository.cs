using MotCua.Model;
using MotCua.Model.Data;
using MotCua.Repository.Infrastructure;
using System.Linq;

namespace MotCua.Repository
{
    public interface IRoleRepository : IRepository<Role>
    {
        void RemoveRange(IQueryable<Role> role);
    }
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(MotCuaDbContext dbContext) : base(dbContext)
        {
        }

        public void RemoveRange(IQueryable<Role> role)
        {
            _dbContext.Roles.RemoveRange(role);
        }
    }
}
