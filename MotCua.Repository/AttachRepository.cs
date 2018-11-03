using MotCua.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotCua.Model;
using MotCua.Model.Data;

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
