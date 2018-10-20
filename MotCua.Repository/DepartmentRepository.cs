using MotCua.Model;
using MotCua.Model.Data;
using MotCua.Repository.Infrastructure;

namespace MotCua.Repository
{
    public interface IDepartmentRepository : IRepository<Department>
    {

    }
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MotCuaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
