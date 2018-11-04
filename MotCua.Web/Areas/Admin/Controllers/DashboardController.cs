using MotCua.Helper;
using MotCua.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotCua.Helper.Common;

namespace MotCua.Web.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "admin")]
    public class DashboardController : Controller
    {
        IRequestService _requestService;
        public DashboardController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult QuickStatic()
        {
            ViewBag.TotalRequest = _requestService.GetAll().Count();
            ViewBag.TotalRequestSuccess = _requestService.GetAll().Where(x=>x.Status == RequestStatus.Success).Count();
            ViewBag.TotalRequestProcessing = _requestService.GetAll().Where(x => x.Status == RequestStatus.Processing).Count();
            return PartialView();
        }
    }
}