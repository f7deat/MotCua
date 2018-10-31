using MotCua.Model;
using MotCua.Model.Data;
using MotCua.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotCua.Repository
{
    public interface IGroupRepository : IRepository<Group>
    {

    }
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(MotCuaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
