using MotCua.Model;
using MotCua.Model.Data;
using MotCua.Repository.Infrastructure;
using System.Linq;

namespace MotCua.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        int Login(int userId, string password);
    }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MotCuaDbContext dbContext) : base(dbContext)
        {
        }

        public int Login(int userId, string password)
        {
            var count = _dbContext.Users.Count(x => x.UserId == userId && x.Password == password);
            var user = GetById(userId);
            if (count > 0)
            {
                var group = user.GroupId;
                if(group == 1)
                {
                    return 1; // admin
                }
                else
                {
                    if(user.Status == false)
                    {
                        return -2;
                    }
                    else
                    return 2; // student
                }
            }
            else
                return -1;
        }
    }
}
