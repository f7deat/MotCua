using MotCua.Model;
using MotCua.Repository;
using MotCua.Service.Infrastructure;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MotCua.Service
{
    public interface IGroupService : IService<Group>
    {

    }
    public class GroupService : IGroupService
    {
        private IGroupRepository _groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public Group Add(Group user)
        {
            return _groupRepository.Add(user);
        }

        public bool Delete(Group user)
        {
            return _groupRepository.Delete(user);
        }

        public IQueryable<Group> FindBy(Expression<Func<Group, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public Group GetById(int id)
        {
            return _groupRepository.GetById(id);
        }

        public bool Update(Group user)
        {
            return _groupRepository.Update(user);
        }
    }
}
