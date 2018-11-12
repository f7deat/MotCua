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
    public interface IRoleService : IService<Role>
    {
        void RemoveRange(IQueryable<Role> role);
    }
    public class RoleService : IRoleService
    {
        IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public Role Add(Role entity)
        {
            return _roleRepository.Add(entity);
        }

        public bool Delete(Role entity)
        {
            return _roleRepository.Delete(entity);
        }

        public IQueryable<Role> FindBy(Expression<Func<Role, bool>> predicate)
        {
            return _roleRepository.FindBy(predicate);
        }

        public IQueryable<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public Role GetById(int id)
        {
            return _roleRepository.GetById(id);
        }

        public void RemoveRange(IQueryable<Role> role)
        {
            _roleRepository.RemoveRange(role);
        }

        public bool Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
