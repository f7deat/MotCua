using MotCua.Helper;
using System.Linq;
using System.Web.Mvc;
using MotCua.Service;
using MotCua.Helper.Session;
using MotCua.Helper.Common;
using PagedList;

namespace MotCua.Web.Areas.Student.Controllers
{
    [CustomAuthorize(Roles = "student")]
    public class DashboardsController : Controller
    {
        IRequestService _requestService;
        public DashboardsController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        // GET: Student/Dashboards
        public ActionResult Index(int? page)
        {
            var session = (UserSessionModel)Session[Constants.USER_SESSION];
            ViewBag.TotalRequest = _requestService.GetAll().Where(x => x.UserId == session.UserId).Count();
            ViewBag.TotalRequestSuccess = _requestService.GetAll().Where(x => x.Status == RequestStatus.Success && x.UserId == session.UserId).Count();
            ViewBag.TotalRequestProcessing = _requestService.GetAll().Where(x => x.Status == RequestStatus.Processing && x.UserId == session.UserId).Count();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(_requestService.GetAll().Where(x=>x.UserId == session.UserId).OrderByDescending(x => x.RequestDate).ToPagedList(pageNumber, pageSize));
        }
    }
}