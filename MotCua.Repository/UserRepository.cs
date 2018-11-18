using MotCua.Model;
using MotCua.Model.Data;
using MotCua.Repository.Infrastructure;
using System.Linq;

namespace MotCua.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        int Login(int userId, string password);
        void Save();
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
            var group = _dbContext.Groups.Find(user.GroupId);
            if (count > 0)
            {
                if(group.GroupName.Trim().ToLower() != "student")
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

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
