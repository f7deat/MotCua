using MotCua.Model;
using MotCua.Repository;
using MotCua.Service.Infrastructure;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MotCua.Service
{
    public interface IFacultyService : IService<Faculty>
    {

    }
    public class FacultyService : IFacultyService
    {
        private IFacultyRepository _facultyRepository;
        public FacultyService(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }
        public Faculty Add(Faculty entity)
        {
            return _facultyRepository.Add(entity);
        }

        public bool Delete(Faculty entity)
        {
            return _facultyRepository.Delete(entity);
        }

        public IQueryable<Faculty> FindBy(Expression<Func<Faculty, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Faculty> GetAll()
        {
            return _facultyRepository.GetAll();
        }

        public Faculty GetById(int id)
        {
            return _facultyRepository.GetById(id);
        }

        public bool Update(Faculty entity)
        {
            return _facultyRepository.Update(entity);
        }
    }
}
