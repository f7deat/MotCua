﻿using MotCua.Model;
using MotCua.Repository;
using MotCua.Service.Infrastructure;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MotCua.Service
{
    public interface IDepartmentService : IService<Department>
    {

    }
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public Department Add(Department user)
        {
            return _departmentRepository.Add(user);
        }

        public bool Delete(Department user)
        {
            return _departmentRepository.Delete(user);
        }

        public IQueryable<Department> FindBy(Expression<Func<Department, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        public Department GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public bool Update(Department user)
        {
            return _departmentRepository.Update(user);
        }
    }
}
