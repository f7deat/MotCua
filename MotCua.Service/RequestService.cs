using MotCua.Model;
using MotCua.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MotCua.Service
{
    public interface IRequestService
    {
        Request Add(Request request);
        bool Delete(Request request);
        bool Update(Request request);
        IQueryable<Request> FindBy(Expression<Func<Request, bool>> predicate);
        IQueryable<Request> GetAll();
        Request GetById(int id);
        bool ChangeStatus(int id, int status);
    }
    public class RequestService : IRequestService
    {
        IRequestRepository _requestRepository;
        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public Request Add(Request request)
        {
            request.RequestDate = DateTime.Now;
            request.Status = 0;
            return _requestRepository.Add(request);
        }

        public bool ChangeStatus(int id, int status)
        {
            var request = _requestRepository.GetById(id);
            if (request.DateReceived == null)
            {
                request.DateReceived = DateTime.Now;
            }
            request.Status = status;
            return _requestRepository.ChangeStatus(id, status);
        }

        public bool Delete(Request request)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Request> FindBy(Expression<Func<Request, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Request> GetAll()
        {
            return _requestRepository.GetAll();
        }

        public Request GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
