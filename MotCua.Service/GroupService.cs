using MotCua.Model;
using MotCua.Repository;
using MotCua.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MotCua.Service
{
    public interface IGroupService : IService<Group>
    {

    }
    public class GroupService : IGroupService
    {
        IGroupRepository _groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public Group Add(Group user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Group user)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Group> FindBy(Expression<Func<Group, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Group> GetAll() => _groupRepository.GetAll();

        public Group GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Group user)
        {
            throw new NotImplementedException();
        }
    }
}
