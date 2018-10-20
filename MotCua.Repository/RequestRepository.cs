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
    public interface IRequestRepository : IRepository<Request>
    {

    }
    public class RequestRepository : BaseRepository<Request>, IRequestRepository
    {
        public RequestRepository(MotCuaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
