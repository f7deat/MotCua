using MotCua.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotCua.Model;
using System.Linq.Expressions;
using MotCua.Repository;

namespace MotCua.Service
{
    public interface IAttachService: IService<Attach>
    {

    }
    public class AttachService : IAttachService
    {
        IAttachRepository _attachRepository;
        public AttachService(IAttachRepository attachRepository)
        {
            _attachRepository = attachRepository;
        }
        public Attach Add(Attach entity)
        {
            return _attachRepository.Add(entity);
        }

        public bool Delete(Attach user)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Attach> FindBy(Expression<Func<Attach, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Attach> GetAll()
        {
            return _attachRepository.GetAll();
        }

        public Attach GetById(int id)
        {
            return _attachRepository.GetById(id);
        }

        public bool Update(Attach user)
        {
            throw new NotImplementedException();
        }
    }
}
