using MotCua.Model;
using MotCua.Model.Data;
using MotCua.Repository.Infrastructure;

namespace MotCua.Repository
{
    public interface IAttachRepository : IRepository<Attach>
    {

    }
    public class AttachRepository : BaseRepository<Attach>, IAttachRepository
    {
        public AttachRepository(MotCuaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
