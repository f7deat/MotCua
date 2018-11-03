using MotCua.Helper;
using System.Linq;
using System.Web.Mvc;
using MotCua.Service;
using MotCua.Helper.Session;
using MotCua.Helper.Common;

namespace MotCua.Web.Areas.Student.Controllers
{
    [CustomAuthorize(Roles = "student")]
    public class DashboardsController : Controller
    {
        IRequestService _requestService;
        IAttachService _attachService;
        public DashboardsController(IRequestService requestService, IAttachService attachService)
        {
            _requestService = requestService;
            _attachService = attachService;
        }
        // GET: Student/Dashboards
        public ActionResult Index()
        {
            var session = (UserSessionModel)Session[Constants.USER_SESSION];
            ViewBag.TotalRequest = _requestService.GetAll().Where(x => x.UserId == session.UserId).Count();
            ViewBag.ListAttach = _attachService.GetAll();
            return View(_requestService.GetAll().Where(x=>x.UserId == session.UserId));
        }
    }
}