using MotCua.Model;
using MotCua.Model.Data;
using MotCua.Repository.Infrastructure;

namespace MotCua.Repository
{
    public interface IUserRepository : IRepository<User>
    {

    }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MotCuaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
