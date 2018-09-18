using MotCua.Model;
using MotCua.Repository;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MotCua.Service
{
    public interface IUserService
    {
        User Add(User user);
        bool Delete(User user);
        bool Update(User user);
        IQueryable<User> FindBy(Expression<Func<User, bool>> predicate);
        IQueryable<User> GetAll();
        User GetById(int id);
    }
    public class UserService : IUserService
    {
        public IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public User Add(User user)
        {
            return userRepository.Add(user);
        }

        public bool Delete(User user)
        {
            return userRepository.Delete(user);
        }

        public IQueryable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            return userRepository.FindBy(predicate);
        }

        public IQueryable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public bool Update(User user)
        {
            return userRepository.Update(user);
        }
    }
}
