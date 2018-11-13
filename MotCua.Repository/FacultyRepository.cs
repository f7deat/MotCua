using MotCua.Model;
using MotCua.Model.Data;
using MotCua.Repository.Infrastructure;

namespace MotCua.Repository
{
    public interface IFacultyRepository : IRepository<Faculty>
    {

    }
    public class FacultyRepository : BaseRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(MotCuaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
