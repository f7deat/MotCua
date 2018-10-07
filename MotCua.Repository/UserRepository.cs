using MotCua.Model;
using MotCua.Model.Data;
using MotCua.Repository.Infrastructure;
using System.Linq;

namespace MotCua.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        bool Login(int userId, string password);
    }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MotCuaDbContext dbContext) : base(dbContext)
        {
        }

        public bool Login(int userId, string password)
        {
            var count = _dbContext.Users.Count(x => x.UserId == userId && x.Password == password);
            if (count > 0)
                return true;
            else
                return false;
        }
    }
}
