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
    public interface ICategoryRepository : IRepository<Category>
    {

    }
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MotCuaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
