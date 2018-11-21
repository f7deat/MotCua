using MotCua.Helper;
using System.Linq;
using System.Web.Mvc;
using MotCua.Service;
using MotCua.Helper.Session;
using MotCua.Helper.Common;
using PagedList;
using MotCua.Web.Areas.Admin.Controllers;

namespace MotCua.Web.Areas.Student.Controllers
{
    public class DashboardsController : BaseController
    {
        IRequestService _requestService;
        private IDepartmentService _departmentService;
        public DashboardsController(IRequestService requestService, IDepartmentService departmentService)
        {
            _requestService = requestService;
            _departmentService = departmentService;
        }

        public ActionResult Index(int? page, int? DepartmentId)
        {
            ViewBag.ListDepartments = _departmentService.GetAll();
            var session = (UserSessionModel)Session[Constants.USER_SESSION];
            ViewBag.TotalRequest = _requestService.GetAll().Where(x => x.UserId == session.UserId).Count();
            ViewBag.TotalRequestSuccess = _requestService.GetAll().Where(x => x.Status == RequestStatus.Success && x.UserId == session.UserId).Count();
            ViewBag.TotalRequestProcessing = _requestService.GetAll().Where(x => x.Status == RequestStatus.Processing && x.UserId == session.UserId).Count();
            ViewBag.TotalRequestOutOfDate = _requestService.GetAll().Where(x => x.Status == RequestStatus.OutOfDate).Count();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var model = _requestService.GetAll().Where(x => x.UserId == session.UserId).OrderByDescending(x => x.RequestDate).ToPagedList(pageNumber, pageSize);
            if(DepartmentId != null)
            {
                model = _requestService.GetAll().Where(x => x.UserId == session.UserId && x.DepartmentId == DepartmentId).OrderByDescending(x => x.RequestDate).ToPagedList(pageNumber, pageSize);
                ViewBag.DepartmentId = DepartmentId;
            }
            return View(model);
        }
    }
}